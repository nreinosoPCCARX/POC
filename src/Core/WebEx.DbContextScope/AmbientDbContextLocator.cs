using System.Data.Entity;
using WebEx.DbContextScope.Interfaces;

namespace WebEx.DbContextScope
{
    public class AmbientDbContextLocator : IAmbientDbContextLocator
    {
        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            var ambientDbContextScope = DbContextScope.GetAmbientScope();

            if(ambientDbContextScope != null)
            {
                return ambientDbContextScope.DbContexts.GetContext<TDbContext>();
            }

            return null;
        }
    }
}
