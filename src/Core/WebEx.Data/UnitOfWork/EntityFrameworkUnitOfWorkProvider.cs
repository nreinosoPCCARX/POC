using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Interfaces.Interfaces;

namespace WebEx.Data.UnitOfWork
{
    public class EntityFrameworkUnitOfWorkProvider : IUnitOfWorkProvider
    {
        public IUnitOfWork Create() => new EntityFrameworkUnitOfWork(null);
    }
}
