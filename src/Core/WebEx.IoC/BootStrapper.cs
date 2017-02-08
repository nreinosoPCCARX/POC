using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebEx.Interfaces.Interfaces;

namespace WebEx.IoC
{
    public class Bootstrapper
    {
        private static IKernel _kernel;

        public Bootstrapper()
        {
            //the main components
            _kernel = BuildKernel();

            StartAllModules();
        }

        void StartAllModules()
        {
            foreach(var module in  _kernel.GetAll<IModule>())
            {
                //do something maybe?
            }
        }

        IKernel BuildKernel()
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
