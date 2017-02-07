namespace WebEx.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExDataContext : DbContext
    {
        public ExDataContext()
            : base("name=ExDataContext")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Id);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.Country_Id);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.StateProvinces)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.Country_Id);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Emails)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Notes)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Phones)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Websites)
                .WithOptional(e => e.Organization)
                .HasForeignKey(e => e.Organization_Id);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Emails)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Notes)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Phones)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Websites)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.Person_Id);

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.StateProvince)
                .HasForeignKey(e => e.StateProvince_Id);

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Cities)
                .WithOptional(e => e.StateProvince)
                .HasForeignKey(e => e.StateProvnice_Id);
        }
    }
}
