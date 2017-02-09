using System;
using System.Data.Entity;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IDbContextCollection : IDisposable
    {
        TDbContext Get<TDbContext>() where TDbContext : DbContext;

        int Commit();
    }
}
