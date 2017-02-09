using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.DbContextScope
{
    public class DbContextCollection : IDbContextCollection
    {
        Dictionary<Type, DbContext> _dbContexts;
        readonly IRepositoryFactory _factory;

        bool _disposed;
        bool _completed;
        ISession _session;

        public DbContextCollection(ISession session, IRepositoryFactory factory)
        {
            _disposed = false;
            _completed = false;
            _session = session;
            _factory = factory;

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

        public IRepository GetRepository<TDbContext>() where TDbContext : DbContext
        {
            return _factory.Create<TDbContext>();
        }

        public TDbContext GetContext<TDbContext>() where TDbContext : DbContext
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
