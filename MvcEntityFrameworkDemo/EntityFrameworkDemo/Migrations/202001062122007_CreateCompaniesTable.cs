namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCompaniesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entities", "CompanyName", c => c.String());
            AddColumn("dbo.Entities", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Entities", "Discriminator");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entities", "Discriminator");
            DropColumn("dbo.Entities", "CompanyName");
            DropIndex("dbo.Entities", new[] { "Discriminator" });
        }
    }
}
