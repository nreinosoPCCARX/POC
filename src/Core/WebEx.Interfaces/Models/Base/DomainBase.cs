using WebEx.Interfaces.Models.Interfaces;

namespace WebEx.Interfaces.Models.Base
{
    public abstract class DomainBase : IDomain
    {
        public long Id { get; set; }
    }
}
