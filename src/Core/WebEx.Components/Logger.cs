using System;
using WebEx.Components.Attributes;
using WebEx.Interfaces.Interfaces.Components;

namespace WebEx.Components
{
    [Component]
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
