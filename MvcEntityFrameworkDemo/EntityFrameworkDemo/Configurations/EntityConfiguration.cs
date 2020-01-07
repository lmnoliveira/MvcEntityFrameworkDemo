using DomainModelsDemo;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Configurations
{
    class EntityConfiguration : EntityTypeConfiguration<Entity>
    {
        internal EntityConfiguration()
        {
            HasKey(m => m.Id);
        }
    }
}
