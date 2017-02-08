using System;
using WebEx.Interfaces.Interfaces.Components;
using WebEx.Person.Interface;

namespace WebEx.Person.Module
{
    public class PersonModule : IPersonModule
    {
        readonly ILogger _logger;

        public PersonModule(ILogger logger)
        {
            _logger = logger;

            _logger.Log("PersonModule Created");
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
