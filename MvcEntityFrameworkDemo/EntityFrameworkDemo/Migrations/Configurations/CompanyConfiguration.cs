using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkDemo.Migrations.Configurations
{
    internal class CompanyConfiguration : EntityTypeConfiguration<DomainModels.Company>
    {
        internal CompanyConfiguration()
        {
            this.Map(m =>
            {
                m.Properties(c => new { c.Id, c.CompanyName });
                m.ToTable("Companies");
            });
        }
    }
}
