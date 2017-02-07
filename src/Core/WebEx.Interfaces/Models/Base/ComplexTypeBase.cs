using System;

namespace WebEx.Interfaces.Models.Base
{
    public abstract class ComplexTypeBase : ICloneable
    {
        protected ComplexTypeBase() { }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
