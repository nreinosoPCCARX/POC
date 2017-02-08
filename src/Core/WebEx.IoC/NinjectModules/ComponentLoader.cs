using Ninject.Modules;
using WebEx.Components;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.IoC.NinjectModules
{
    public class ComponentLoader : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
        }
    }
}
