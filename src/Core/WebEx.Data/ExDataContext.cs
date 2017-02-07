using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebEx.Interfaces.Models;
using WebEx.Interfaces.Models.Interfaces;
using WebEx.Interfaces.Models.Enums;

namespace WebEx.Data
{
    public class ExDataContext : DbContext
    {
        public ExDataContext()
            : base("name=Default")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<Website> Websites { get; set; }

        public override int SaveChanges()
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
                        archivable.AuditLog.UserName = "GetSomehowAdded...";
                        break;
                    case EntityState.Modified:
                        var cloned = entity.Entity.Clone() as IArchivable;
                        cloned.State = ArchiveState.Modified;
                        cloned.IsCurrent = true;
                        cloned.AuditLog.TimeStamp = DateTime.UtcNow;
                        cloned.AuditLog.UserName = "GetSomehowModified...";
                        cloned.ParentId = entity.Entity.Id;
                        cloned.BaseParentId = cloned.BaseParentId ?? entity.Entity.Id;
                        cloned.Id = 0;
                        Set(cloned.GetType()).Add(cloned);

                        //entity.CurrentValues.SetValues(entity.OriginalValues);
                        entity.Reload();
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
                        deleted.AuditLog.UserName = "GetSomehowDeleted...";
                        deleted.ParentId = entity.Entity.Id;
                        deleted.BaseParentId = deleted.BaseParentId ?? entity.Entity.Id;
                        deleted.Id = 0;
                        Set(deleted.GetType()).Add(deleted);

                        //entity.CurrentValues.SetValues(entity.OriginalValues);
                        entity.Reload();
                        var parent = entity.Entity as IArchivable;
                        parent.IsCurrent = false;
                        entity.State = EntityState.Modified;
                        break;
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
