using System;

namespace WebEx.Interfaces.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ComponentAttribute : Attribute
    {
        public string FriendlyName { get; set; }

        public string Description { get; set; }
    }
}
