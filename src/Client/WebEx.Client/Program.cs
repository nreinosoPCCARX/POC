using Ninject;
using System;
using System.Windows.Forms;
using WebEx.Interfaces.Interfaces.Modules;
using WebEx.IoC;

namespace WebEx.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var kernel = Bootstrapper.BuildKernel();

            foreach(var module in kernel.GetAll<IUIModule>())
            {

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
