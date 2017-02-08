using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Person.Module
{
    public class PersonModule : IModule
    {
        readonly ILogger _logger;

        public PersonModule(ILogger logger)
        {
            _logger = logger;

            _logger.Log("PersonModule Created");
        }
    }
}
