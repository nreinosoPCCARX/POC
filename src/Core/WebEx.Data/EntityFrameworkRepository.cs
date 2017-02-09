using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Models.Interfaces;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.Data
{
    public class EntityFrameworkRepository : IRepository
    {
        IAmbientDbContextLocator _dbContextLocator;

        public EntityFrameworkRepository(IAmbientDbContextLocator dbContextLocator)
        {
            _dbContextLocator = dbContextLocator;
        }

        public void Add<T>(T entity) where T : class
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            var dbSet = context.Set<T>();
            if (dbSet != null)
            {
                dbSet.Add(entity);
            }
        }

        public IEnumerable<T> Find<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            foreach (var entity in context.Set<T>().AsEnumerable())
            {
                yield return entity;
            }
        }

        public T GetById<T>(long id) where T : class, IDomain
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            return context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Remove<T>(T entity) where T : class
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            var dbSet = context.Set<T>();
            if (dbSet != null)
            {
                dbSet.Remove(entity);
            }
        }
    }
}
