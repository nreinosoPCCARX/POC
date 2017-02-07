using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Data;
using WebEx.Interfaces.WebEx.Interfaces;

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


}
