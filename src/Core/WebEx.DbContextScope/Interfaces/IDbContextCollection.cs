using System;
using System.Data.Entity;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IDbContextCollection : IDisposable
    {
        IRepository GetRepository<TDbContext>() where TDbContext : DbContext;

        TDbContext GetContext<TDbContext>() where TDbContext : DbContext;

        int Commit();
    }
}
