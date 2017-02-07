using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEx.Interfaces
{

    namespace WebEx.Interfaces
    {
        public interface IDataRepository
        {
            void Add<T>(T entity) where T : class;
            IEnumerable<T> GetAll<T>() where T : class;
            T GetById<T>(long id) where T : class;
            void Update<T>(T entity) where T : class;
            void Remove<T>(T entity) where T : class;
        }
    }

}
