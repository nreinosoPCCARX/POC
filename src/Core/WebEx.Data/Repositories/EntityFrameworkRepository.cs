using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Data.Models;

namespace WebEx.Data.Repositories
{
    public class EntityFrameworkRepository : IDataRepository
    {
        public void Add<T>(T entity) where T : class
        {
            using (var context = new ExDataContext())
            {
                var dbSet = context.Set<T>();
                if (dbSet != null)
                {
                    dbSet.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            using (var context = new ExDataContext())
            {
                return context.Set<T>().AsEnumerable<T>();
            }
        }

        public T GetById<T>(long id) where T : class
        {
            using (var context = new ExDataContext())
            {
                var dbSet = context.Set<T>();
                return dbSet.Find(new[] { id });
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            using (var context = new ExDataContext())
            {
                var dbSet = context.Set<T>();
                if (dbSet != null)
                {
                    dbSet.Attach(entity);
                    dbSet.Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }

    public interface IDataRepository
    {
        void Add<T>(T entity) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        T GetById<T>(long id) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
    }
}
