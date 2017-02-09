using Ninject.Modules;
using WebEx.Components;
using WebEx.Data;
using WebEx.DbContextScope;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces.Components;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.IoC.NinjectModules
{
    public class ComponentLoader : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
            Bind<IUserSessionManager>().To<UserSessionManager>();
            Bind<IDbContextScopeFactory>().To<DbContextScopeFactory>();
            Bind<IAmbientDbContextLocator>().To<AmbientDbContextLocator>();
            Bind<IRepository>().To<EntityFrameworkRepository>();
        }
    }
}
