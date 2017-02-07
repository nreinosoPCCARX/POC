using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEx.Interfaces.Interfaces
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();
    }
}
