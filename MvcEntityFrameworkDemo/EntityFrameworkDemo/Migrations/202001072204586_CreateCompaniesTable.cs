namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCompaniesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Entities", "Discriminator", c => c.String(maxLength: 128));
            DropColumn("dbo.Entities", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "CompanyName", c => c.String());
            DropForeignKey("dbo.Companies", "Id", "dbo.Entities");
            DropIndex("dbo.Companies", new[] { "Id" });
            AlterColumn("dbo.Entities", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Companies");
        }
    }
}
