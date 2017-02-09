using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.DbContextScope
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        readonly IUserSessionManager _sessionManager;

        public DbContextScopeFactory(IUserSessionManager sessionMgr)
        {
            _sessionManager = sessionMgr;
        }

        public IDbContextScope Create()
        {
            return new DbContextScope(_sessionManager.CurrentSession);
        }
    }
}
