using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Interfaces.Interfaces;

namespace WebEx.Data.Components
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        public EntityFrameworkUnitOfWork(ISession session)
        {
            DataContext = new ExDataContext();
            Session = session;
        }

        public ExDataContext DataContext { get; }

        public ISession Session { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}