using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.DbContextScope
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        readonly IUserSessionManager _sessionManager;
        readonly IRepositoryFactory _factory;

        public DbContextScopeFactory(IUserSessionManager sessionMgr, IRepositoryFactory factory)
        {
            _sessionManager = sessionMgr;
            _factory = factory;
        }

        public IDbContextScope Create()
        {
            return new DbContextScope(_sessionManager.CurrentSession, _factory);
        }
    }
}
