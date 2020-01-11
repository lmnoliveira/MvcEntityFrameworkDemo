using EntityFrameworkDemo.Configurations;
using System.Data.Entity;

namespace EntityFrameworkDemo.Repositories
{
    sealed class MigrationsRepository : RepositoryBase<MigrationsRepository>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CondominiumConfiguration());
            modelBuilder.Configurations.Add(new ZoneConfiguration());
            modelBuilder.Configurations.Add(new EntityConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
        }
    }
}
