using System.Data.Entity;
using WebEx.Interfaces.Models;
using WebEx.Interfaces.Interfaces;
using WebEx.DbContextScope;

namespace WebEx.Data
{
    public class ExDataContext : DbContextBase
    {
        public ExDataContext(ISession session) : base(session, "name=Default") { }

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
