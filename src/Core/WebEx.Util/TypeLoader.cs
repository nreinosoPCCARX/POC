using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Pcca.Core.Utilities
{
    public static class TypeLoader
    {
        public static IList<Type> LoadTypes(Type type, string path, string searchPattern)
        {
            var list = new List<Type>();

            if (type != null && !string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(searchPattern))
            {
                var uri = new Uri(path);

                if (Directory.Exists(path) && !uri.IsUnc)
                {
                    //use an appdomain to prevent dll locking by unloading domain when we are done
                    var domain = AppDomain.CreateDomain("TypeLoaderDomain", null, path, null, false);

                    var helper = (TypeLoaderHelper)domain?.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(TypeLoaderHelper).FullName);

                    if (helper != null)
                    {
                        foreach (var typeName in helper.FindTypes(type.AssemblyQualifiedName, path, searchPattern))
                        {
                            list.Add(Type.GetType(typeName));
                        }
                    }

                    AppDomain.Unload(domain);
                }
            }

            return list;
        }

        public class TypeLoaderHelper : MarshalByRefObject
        {
            public IEnumerable<string> FindTypes(string typeName, string path, string searchPattern)
            {
                if (!string.IsNullOrEmpty(typeName) && !string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(searchPattern))
                {
                    var searchingType = Type.GetType(typeName);

                    foreach (var fileName in Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories))
                    {
                        var fileInfo = new FileInfo(fileName);

                        if (fileInfo.Extension == "dll")
                        {
                            var assembly = Assembly.LoadFrom(fileName);  //TODO: Verify assembly signature after loading, might only be able to in release mode :S

                            foreach (var foundType in assembly.GetTypes().Where(t => t != searchingType && searchingType.IsAssignableFrom(t)))
                            {
                                yield return foundType.AssemblyQualifiedName;
                            }
                        }
                    }
                }
            }
        }
    }
}
