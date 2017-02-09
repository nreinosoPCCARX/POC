using System.Data.Entity;
using WebEx.DataModule.Models;
using WebEx.DbContextScope;
using WebEx.Interfaces.Interfaces;

namespace WebEx.DataModule
{
    public class SecondaryDbContext : DbContextBase
    {
        public SecondaryDbContext(ISession session) : base(session, "name=DataModule") { }

        public DbSet<TestThing> Things { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestThing>();
        }
    }
}
