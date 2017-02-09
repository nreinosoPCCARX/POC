using System;
using System.Data.Entity;
using WebEx.Interfaces.Models;
using WebEx.Interfaces.Models.Interfaces;
using WebEx.Interfaces.Models.Enums;
using WebEx.Interfaces.Interfaces;

namespace WebEx.Data
{
    public class ExDataContext : DbContext
    {
        readonly ISession _session;

        public ExDataContext(ISession session)
            : base("name=Default")
        {
            _session = session;
        }

        public bool DisableAuditing { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        public DbSet<Website> Websites { get; set; }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.City);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Country);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.StateProvinces)
                .WithOptional(e => e.Country);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Emails)
                .WithOptional(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Notes)
                .WithOptional(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Phones)
                .WithOptional(e => e.Organization);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Websites)
                .WithOptional(e => e.Organization);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Emails)
                .WithOptional(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Notes)
                .WithOptional(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Phones)
                .WithOptional(e => e.Person);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Websites)
                .WithOptional(e => e.Person);

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.StateProvince);

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.StateProvince);
        }
    }
}
