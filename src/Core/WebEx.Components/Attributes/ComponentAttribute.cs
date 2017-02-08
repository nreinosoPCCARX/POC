using System;

namespace WebEx.Components.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ComponentAttribute : Attribute
    {
        public string FriendlyName { get; set; }

        public string Description { get; set; }
    }
}
