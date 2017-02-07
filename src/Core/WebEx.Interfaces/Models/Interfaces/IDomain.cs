using System;

namespace WebEx.Interfaces.Models.Interfaces
{
    public interface IDomain : ICloneable
    {
        long Id { get; set; }
    }
}
