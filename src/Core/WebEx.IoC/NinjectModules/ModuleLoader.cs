using Ninject.Modules;
using Ninject.Extensions.Conventions;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Modules;

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

            Kernel.Bind(s => s.FromAssembliesMatching("*.UIModule.dll")
              .SelectAllClasses()
              .InheritedFrom<IUIModule>()
              .BindDefaultInterfaces()
       );
        }
    }
}
