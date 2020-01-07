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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "Id", "dbo.Entities");
            DropIndex("dbo.Companies", new[] { "Id" });
            DropTable("dbo.Companies");
        }
    }
}
