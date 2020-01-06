using System.Data.Entity;

namespace EntityFrameworkDemo.Migrations
{
    internal class MigrationsDbContext : Repositories.RepositoryBase<MigrationsDbContext>
    {
        internal DbSet<DomainModels.Condominium> Condominium { get; set; }
        internal DbSet<DomainModels.Zone> Zone { get; set; }
        internal DbSet<DomainModels.Entity> Entity { get; set; }
        internal DbSet<DomainModels.Company> Company { get; set; }
        internal DbSet<DomainModels.Fraction> Fraction { get; set; }
        //internal DbSet<DomainModels.EntitiesFractions> EntitiesFractions { get; set; }
    }
}
