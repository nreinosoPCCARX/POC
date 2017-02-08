using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebEx.Interfaces.Interfaces;

namespace WebEx.IoC
{
    public static class Bootstrapper
    {
        public static IKernel BuildKernel()
        {
            var modules = new List<INinjectModule>();

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(NinjectModule).IsAssignableFrom(t)).ToList();

            foreach(var type in types)
            {
                modules.Add(Activator.CreateInstance(type) as INinjectModule);
            }

            return new StandardKernel(modules.ToArray());
        }
    }
}
