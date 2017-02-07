using WebEx.Interfaces.Models.Enums;

namespace WebEx.Interfaces.Models.Interfaces
{
    public interface IArchivable: IRemovable, IAuditable
    {
        ArchiveState State { get; set; }

        bool IsCurrent { get; set; }
    }
}
