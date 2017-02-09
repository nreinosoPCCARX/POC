using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebEx.Interfaces.Models.Interfaces;

namespace WebEx.Interfaces
{
    namespace WebEx.Interfaces
    {
        public interface IRepository
        {
            void Add<T>(T entity) where T : class, IDomain;

            IEnumerable<T> GetAll<T>() where T : class, IDomain;

            IEnumerable<T> GetAll<T>(bool includeRemoved, bool includeArchived) where T : class, IArchivable;

            IEnumerable<T> GetAll<T>(bool includeRemoved) where T : class, IRemovable;

            T GetById<T>(long id) where T : class, IDomain;

            IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : class, IDomain;

            IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved, bool includeArchived) where T : class, IArchivable;

            IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved) where T : class, IRemovable;

            void Remove<T>(T entity) where T : class, IDomain;

            void Unarchive<T>(T entity) where T : class, IArchivable;

            void Replace<T>(T entity) where T : class, IRemovable;
        }
    }

}
