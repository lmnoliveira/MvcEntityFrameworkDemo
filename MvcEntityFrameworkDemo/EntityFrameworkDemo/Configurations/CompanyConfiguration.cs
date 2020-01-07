using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Configurations
{
    class CompanyConfiguration : EntityTypeConfiguration<DomainModelsDemo.Company>
    {
        internal CompanyConfiguration()
        {
            Map(m =>
            {
                m.Properties(c => new { c.Id, c.CompanyName });
                m.ToTable("Companies");
            });
        }
    }
}
