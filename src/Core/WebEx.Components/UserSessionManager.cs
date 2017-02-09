using System.Runtime.Remoting.Messaging;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Components
{
    public class UserSessionManager : IUserSessionManager
    {
        static object syncObject = new object();

        static ISession _currentSession;

        public ISession CurrentSession
        {
            get
            {
                lock(syncObject)
                {
                    return _currentSession;
                }
            }
        }

        public void Loggin(string userName)
        {
            lock(syncObject)
            {
                _currentSession = new Session { UserName = userName };
            }
        }
    }

    public class Session : ISession
    {
        public string UserName { get; set; }
    }
}
