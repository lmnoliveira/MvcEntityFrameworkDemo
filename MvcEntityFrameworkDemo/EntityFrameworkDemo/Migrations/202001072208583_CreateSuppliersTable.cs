namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSuppliersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ServicesDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entities", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Entities", "ServicesDescription");
            DropColumn("dbo.Entities", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entities", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.Entities", "ServicesDescription", c => c.String());
            DropForeignKey("dbo.Suppliers", "Id", "dbo.Entities");
            DropIndex("dbo.Suppliers", new[] { "Id" });
            DropTable("dbo.Suppliers");
        }
    }
}
