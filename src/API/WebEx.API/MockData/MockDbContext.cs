using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.API.MockData
{
    public class MockDbContext : IRepository
    {
        void IRepository.Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.Find<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.Find<T>(Expression<Func<T, bool>> predicate, bool includeRemoved, bool includeArchived)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.GetAll<T>()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.GetAll<T>(bool includeRemoved)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.GetAll<T>(bool includeRemoved, bool includeArchived)
        {
            throw new NotImplementedException();
        }

        T IRepository.GetById<T>(long id)
        {
            throw new NotImplementedException();
        }

        void IRepository.Remove<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository.Replace<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository.Unarchive<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}