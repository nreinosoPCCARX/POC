using System.Runtime.Remoting.Messaging;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces;

namespace WebEx.DbContextScope
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        public IDbContextScope Create()
        {
            var session = CallContext.LogicalGetData("UserSession") as ISession;
            return new DbContextScope(session);
        }
    }
}
