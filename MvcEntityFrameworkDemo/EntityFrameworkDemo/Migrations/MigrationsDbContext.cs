using EntityFrameworkDemo.Migrations.Configurations;
using System.Data.Entity;

namespace EntityFrameworkDemo.Migrations
{
    internal class MigrationsDbContext : Repositories.RepositoryBase<MigrationsDbContext>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());   
        }

        internal DbSet<DomainModels.Condominium> Condominium { get; set; }
        internal DbSet<DomainModels.Zone> Zone { get; set; }
        internal DbSet<DomainModels.Entity> Entity { get; set; }
        internal DbSet<DomainModels.Company> Company { get; set; }
        internal DbSet<DomainModels.Supplier> Supplier { get; set; }
        //internal DbSet<DomainModels.Fraction> Fraction { get; set; }
    }
}
