using Ninject.Modules;
using Ninject.Extensions.Conventions;
using WebEx.Interfaces.Interfaces;

namespace WebEx.IoC.NinjectModules
{
    public class ModuleLoader : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(s => s.FromAssembliesMatching("*.Module.dll")
                          .SelectAllClasses()
                          .InheritedFrom<IModule>()
                          .BindDefaultInterfaces()
                   );
        }
    }
}
