using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Configurations
{
    class SupplierConfiguration : EntityTypeConfiguration<DomainModelsDemo.Supplier>
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
