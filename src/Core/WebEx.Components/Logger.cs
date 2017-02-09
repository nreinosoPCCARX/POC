using System;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Components
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
