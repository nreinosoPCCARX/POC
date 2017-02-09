using System.Data.Entity;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IAmbientDbContextLocator
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;
    }
}
