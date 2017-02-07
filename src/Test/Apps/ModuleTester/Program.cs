using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Interfaces.Components;
using WebEx.IoC;

namespace ModuleTester
{
    public class Program
    {
        public static void Main()
        {
            var booty = Bootstrapper.Instance;

            var moduleLoader = booty.Kernel.Get<IModuleLoader>();
            moduleLoader.LoadModules();

            foreach(var module in booty.Kernel.GetAll<IModule>())
            {
                Console.WriteLine($"Module \"{module.GetType()}\" loaded");
            }

            Console.WriteLine("Press Enter To Exit.");
            Console.ReadLine();
        }
    }
}
