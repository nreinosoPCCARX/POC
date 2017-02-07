using Ninject;
using WebEx.Components;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.IoC
{
    public class Bootstrapper
    {
        static Bootstrapper _instance;

        public static Bootstrapper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Bootstrapper();
                }

                return _instance;
            }
        }


        public IKernel Kernel { get; private set; }

        private Bootstrapper()
        {
            Kernel = new StandardKernel();

            //the main components
            Kernel.Bind<ILogger>().To<Logger>();
            Kernel.Bind<IModuleLoader>().To<ModuleLoader>();
        }
    }
}
