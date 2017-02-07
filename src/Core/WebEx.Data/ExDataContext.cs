using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WebEx.Interfaces.Models;

namespace WebEx.Data
{
    public class ExDataContext : DbContext
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
