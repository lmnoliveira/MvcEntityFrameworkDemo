using EntityFrameworkDemo.DomainModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkDemo.Repositories
{
    public sealed class MigrationsRepository : RepositoryBase<MigrationsRepository>
    {
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
