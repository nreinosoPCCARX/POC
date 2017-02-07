using WebEx.Interfaces.Models.ComplexTypes;
using WebEx.Interfaces.Models.Enums;
using WebEx.Interfaces.Models.Interfaces;

namespace WebEx.Interfaces.Models.Base
{
    public abstract class ArchivableBase : DomainBase, IArchivable
    {
        protected ArchivableBase()
        {
            AuditLog = new AuditInfo();
        }

        public AuditInfo AuditLog { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsRemoved { get; set; }

        public ArchiveState State { get; set; }

        public long? ParentId { get; set; }

        public long? BaseParentId { get; set; }
    }
}
