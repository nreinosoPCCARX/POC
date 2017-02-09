using System.Data.Entity;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository Create<TDbContext>()
            where TDbContext : DbContext;
    }
}
