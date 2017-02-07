using WebEx.Interfaces.Models.Enums;

namespace WebEx.Interfaces.Models.Interfaces
{
    public interface IArchivable: IRemovable, IAuditable, IDomain
    {
        ArchiveState State { get; set; }

        bool IsCurrent { get; set; }

        long? ParentId { get; set; }

        long? BaseParentId { get; set; }
    }
}
