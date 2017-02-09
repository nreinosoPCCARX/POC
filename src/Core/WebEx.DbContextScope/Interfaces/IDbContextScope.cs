using System;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IDbContextScope : IDisposable
    {
        int SaveChanges();

        IDbContextCollection DbContexts { get; }
    }
}
