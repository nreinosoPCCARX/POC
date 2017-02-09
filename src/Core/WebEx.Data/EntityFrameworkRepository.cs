using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Models.Interfaces;
using WebEx.Interfaces.WebEx.Interfaces;
using WebEx.Util;

namespace WebEx.Data
{
    public class EntityFrameworkRepository : IRepository
    {
        IAmbientDbContextLocator _dbContextLocator;

        public EntityFrameworkRepository(IAmbientDbContextLocator dbContextLocator)
        {
            _dbContextLocator = dbContextLocator;
        }

        public void Add<T>(T entity)
            where T : class, IDomain
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            var dbSet = context.Set<T>();
            if (dbSet != null)
            {
                dbSet.Add(entity);
            }
        }

        public void Remove<T>(T entity)
            where T : class, IDomain
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            var dbSet = context.Set<T>();
            if (dbSet != null)
            {
                dbSet.Remove(entity);
            }
        }

        public IEnumerable<T> GetAll<T>(bool includeRemoved, bool includeArchived)
            where T : class, IArchivable
        {
            return Find<T>(c => true, includeRemoved, includeArchived);
        }

        public IEnumerable<T> GetAll<T>(bool includeRemoved)
            where T : class, IRemovable
        {
            return Find<T>(c => true, includeRemoved);
        }

        public IEnumerable<T> GetAll<T>()
            where T : class, IDomain
        {
            return Find<T>(c => true);
        }

        public T GetById<T>(long id)
            where T : class, IDomain
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            return context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate)
            where T : class, IDomain
        {
            var context = _dbContextLocator.Get<ExDataContext>();
            return context.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved, bool includeArchived)
            where T : class, IArchivable
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            if (!includeRemoved)
            {
                predicate = predicate.CombineWithAndAlso(c => !c.IsRemoved);
            }

            if (!includeArchived)
            {
                predicate = predicate.CombineWithAndAlso(c => c.IsCurrent);
            }

            return context.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved)
            where T : class, IRemovable
        {
            var context = _dbContextLocator.Get<ExDataContext>();

            if (!includeRemoved)
            {
                predicate = predicate.CombineWithAndAlso(c => !c.IsRemoved);
            }

            return context.Set<T>().Where(predicate).AsEnumerable();
        }
    }
}
