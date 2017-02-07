﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebEx.Interfaces.Models.Interfaces;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.API.MockData
{
    public class MockDbContext : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public T GetById<T>(long id) where T : class, IDomain
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}