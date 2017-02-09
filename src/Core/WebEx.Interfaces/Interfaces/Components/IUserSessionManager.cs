using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEx.Interfaces.Interfaces.Components
{
    public interface IUserSessionManager
    {
        ISession CurrentSession { get; }

        void Loggin(string userName);
    }
}
