//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WebEx.Util
//{
//    public static class DependencyInjector
//    {
//        public static T Create<T>()
//        {
//            var tType = typeof(T);

//            Type concreteType = null;

//            if (tType.IsClass && !tType.IsInterface && !tType.IsAbstract)
//            {
//                concreteType = tType;
//            }
//            else
//            {
//                concreteType = tType.Assembly.GetTypes().Where(t => tType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface).FirstOrDefault();
//            }

//            if (concreteType != null)
//            {
//                var constructor = concreteType.GetConstructors().FirstOrDefault();

//                if (constructor != null)
//                {
//                    var parameters = new List<object>();

//                    foreach (var parameter in constructor.GetParameters())
//                    {
//                        var paramterType = parameter.ParameterType;

//                            var type = GetFromIoC(paramterType);

//                            if (type != null)
//                            {
//                                var mock = Activator.CreateInstance(type);

//                                var method = type.GetMethod("Create");

//                                if (method != null && mock != null)
//                                {
//                                    parameters.Add(method.Invoke(mock, null));
//                                }
//                            }
//                    }

//                    if (parameters.Count == constructor.GetParameters().Count())
//                    {
//                        return (T)Activator.CreateInstance(concreteType, parameters.ToArray());
//                    }
//                }
//            }

//            return default(T);
//        }

//        private static Type FindMockImplementation(Type parameterType)
//        {
//            var mockBaseType = typeof(MockBase<>);

//            return mockBaseType.Assembly.GetTypes().Where(t => t.BaseType.IsGenericType
//                    && t.BaseType.GetGenericTypeDefinition() == mockBaseType
//                    && t.BaseType.GetGenericArguments().First() == parameterType).FirstOrDefault();
//        }
//    }
