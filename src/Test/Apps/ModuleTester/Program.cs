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
            var booty = new Bootstrapper();

            Console.WriteLine("Press Enter To Exit.");
            Console.ReadLine();
        }
    }
}
