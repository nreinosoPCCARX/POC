using Ninject;
using System;
using WebEx.Interfaces.Attributes;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Components;
using WebEx.Util;

namespace WebEx.Components
{
    [Component]
    public class ModuleLoader : IModuleLoader
    {
        private readonly ILogger _logger;

        public ModuleLoader(ILogger logger)
        {
            _logger = logger;
        }

        public void LoadModules()
        {
            var types = TypeLoader.LoadTypes(typeof(IModule), $"{Environment.CurrentDirectory}", "*.Module.dll");

            using (var kernel = new StandardKernel())
            {
                foreach (var type in types)
                {
                    kernel.Bind<IModule>().To(type).InSingletonScope();
                }
            }

        }

    }
}
