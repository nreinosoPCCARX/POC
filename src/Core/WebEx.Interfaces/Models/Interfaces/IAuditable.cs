using WebEx.Interfaces.Models.ComplexTypes;

namespace WebEx.Interfaces.Models.Interfaces
{
    public interface IAuditable
    {
        AuditInfo AuditLog { get; set; }
    }
}
