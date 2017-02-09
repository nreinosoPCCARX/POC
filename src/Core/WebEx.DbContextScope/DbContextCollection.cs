using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces;

namespace WebEx.DbContextScope
{
    public class DbContextCollection : IDbContextCollection
    {
        Dictionary<Type, DbContext> _dbContexts;

        bool _disposed;
        bool _completed;
        ISession _session;

        public DbContextCollection(ISession session)
        {
            _disposed = false;
            _completed = false;
            _session = session;

            _dbContexts = new Dictionary<Type, DbContext>();
        }

        public void Dispose()
        {
            if(_disposed) { return; }

            if(!_completed)
            {
                Commit();
            }

            foreach(var context in _dbContexts.Values)
            {
                context.Dispose();
            }

            _dbContexts.Clear();
            _disposed = true;
        }

        public TDbContext Get<TDbContext>() where TDbContext : DbContext
        {
            if(_disposed) { throw new ObjectDisposedException(nameof(DbContextCollection)); }

            var type = typeof(TDbContext);

            if(!_dbContexts.ContainsKey(type))
            {
                var dbContext = (TDbContext)Activator.CreateInstance(type, _session);
                _dbContexts.Add(type, dbContext);
            }

            return _dbContexts[type] as TDbContext;
        }

        public int Commit()
        {
            if(_disposed) { throw new ObjectDisposedException(nameof(DbContextCollection)); }

            if( _completed) { throw new Exception("DbContextCollection has already been committed."); }

            var committed = 0;

            foreach(var context in _dbContexts.Values)
            {
                committed += context.SaveChanges();
            }

            _completed = true;

            return committed;
        }
    }
}
