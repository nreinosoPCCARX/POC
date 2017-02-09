using System;
using WebEx.Interfaces.Interfaces;

namespace WebEx.DbContextScope.Interfaces
{
    public interface IDbContextScope : IDisposable
    {
        int SaveChanges();

        IDbContextCollection DbContexts { get; }

        ISession Session { get; }
    }
}
