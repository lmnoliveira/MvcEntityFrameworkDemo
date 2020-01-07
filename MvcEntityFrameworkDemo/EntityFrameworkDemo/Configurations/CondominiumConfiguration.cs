using DomainModelsDemo;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Configurations
{
    class CondominiumConfiguration : EntityTypeConfiguration<Condominium>
    {
        internal CondominiumConfiguration()
        {
            HasKey(m => m.Id );
        }
    }
}
