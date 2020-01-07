using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Migrations.Configurations
{
    internal class SupplierConfiguration : EntityTypeConfiguration<DomainModels.Supplier>
    {
        internal SupplierConfiguration()
        {
            this.Map(m => {
                m.Properties(s => new { s.Id, s.ServicesDescription });
                m.ToTable("Suppliers");
            });
        }
    }
}
