using System.Data.Entity.ModelConfiguration;
using DomainModelsDemo;

namespace EntityFrameworkDemo.Configurations
{
    class ZoneConfiguration : EntityTypeConfiguration<Zone>
    {
        internal ZoneConfiguration()
        {
            this.HasKey(m => m.Id);
        }
    }
}
