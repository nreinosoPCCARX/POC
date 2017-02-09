using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebEx.Interfaces.Interfaces;
using WebEx.Interfaces.Models.Enums;
using WebEx.Interfaces.Models.Interfaces;

namespace WebEx.DbContextScope
{
    public abstract class DbContextBase : DbContext
    {
        protected readonly ISession _session;
        public bool DisableAuditing { get; set; }

        protected DbContextBase(ISession session, string connectionString) : base(connectionString)
        {
            _session = session;
        }

        public override int SaveChanges()
        {
            if (!DisableAuditing)
            {
                ChangeTracker.DetectChanges();

                foreach (var entity in ChangeTracker.Entries<IArchivable>())
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            var archivable = entity.Entity as IArchivable;
                            archivable.IsCurrent = true;
                            archivable.State = ArchiveState.Added;
                            archivable.AuditLog.TimeStamp = DateTime.UtcNow;
                            archivable.AuditLog.UserName = _session?.UserName;
                            break;
                        case EntityState.Modified:
                            var cloned = entity.Entity.Clone() as IArchivable;
                            cloned.State = ArchiveState.Modified;
                            cloned.IsCurrent = true;
                            cloned.AuditLog.TimeStamp = DateTime.UtcNow;
                            cloned.AuditLog.UserName = _session?.UserName;
                            cloned.ParentId = entity.Entity.Id;
                            cloned.BaseParentId = cloned.BaseParentId ?? entity.Entity.Id;
                            cloned.Id = 0;
                            Set(cloned.GetType()).Add(cloned);

                            entity.CurrentValues.SetValues(entity.OriginalValues);
                            var changed = entity.Entity as IArchivable;
                            changed.IsCurrent = false;
                            entity.State = EntityState.Modified;
                            break;
                        case EntityState.Deleted:
                            var deleted = entity.Entity.Clone() as IArchivable;
                            deleted.State = ArchiveState.Removed;
                            deleted.IsCurrent = true;
                            deleted.IsRemoved = true;
                            deleted.AuditLog.TimeStamp = DateTime.UtcNow;
                            deleted.AuditLog.UserName = _session?.UserName;
                            deleted.ParentId = entity.Entity.Id;
                            deleted.BaseParentId = deleted.BaseParentId ?? entity.Entity.Id;
                            deleted.Id = 0;
                            Set(deleted.GetType()).Add(deleted);

                            entity.State = EntityState.Modified;
                            entity.CurrentValues.SetValues(entity.OriginalValues);
                            var parent = entity.Entity as IArchivable;
                            parent.IsCurrent = false;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
