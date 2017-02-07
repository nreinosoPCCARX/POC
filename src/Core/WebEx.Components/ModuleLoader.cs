using WebEx.Interfaces.Attributes;
using WebEx.Interfaces.Components.Interfaces;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Components
{
    [Component]
    public class ModuleLoader : IModuleLoader
    {
        private readonly ILogger _logger;

        public ModuleLoader(ILogger logger)
        {
            _logger = logger;
        }

    }
}
