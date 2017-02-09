using System;
using System.Data.Entity;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.DbContextScope
{
    public class RepositoryFactory : IRepositoryFactory
    {
        readonly IAmbientDbContextLocator _locator;

        public RepositoryFactory(IAmbientDbContextLocator locator)
        {
            _locator = locator;
        }

        public IRepository Create<TDbContext>() where TDbContext : DbContext
        {
            return new EntityFrameworkRepository<TDbContext>(_locator);
        }
    }
}
