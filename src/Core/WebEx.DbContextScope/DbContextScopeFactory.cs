using WebEx.DbContextScope.Interfaces;

namespace WebEx.DbContextScope
{
    public class DbContextScopeFactory : IDbContextScopeFactory
    {
        public IDbContextScope Create()
        {
            return new DbContextScope();
        }
    }
}
