﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.API.MockData
{
    public class MockDbContext : IDataRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(long id) where T : class
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