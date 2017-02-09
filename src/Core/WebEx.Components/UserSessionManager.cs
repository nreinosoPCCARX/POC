using System.Runtime.Remoting.Messaging;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Components
{
    public class UserSessionManager : IUserSessionManager
    {
        public void Loggin(string userName)
        {
            CallContext.LogicalSetData("UserSession", new Session { UserName = userName });
        }
    }

    public class Session : ISession
    {
        public string UserName { get; set; }
    }
}
