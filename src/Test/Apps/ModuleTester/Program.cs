using Ninject;
using System;
using WebEx.Interfaces.Interfaces.Modules;
using WebEx.IoC;

namespace ModuleTester
{
    public class Program
    {
        public static void Main()
        {
            var kernel = Bootstrapper.BuildKernel();

            foreach (var module in kernel.GetAll<IModule>())
            {
                //do something
            }

            Console.WriteLine("Press Enter To Exit.");
            Console.ReadLine();
        }
    }
}
