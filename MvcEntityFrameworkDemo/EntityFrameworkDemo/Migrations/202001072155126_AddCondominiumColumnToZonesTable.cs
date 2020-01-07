namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCondominiumColumnToZonesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zones", "Condominium_Id", c => c.Int());
            CreateIndex("dbo.Zones", "Condominium_Id");
            AddForeignKey("dbo.Zones", "Condominium_Id", "dbo.Condominiums", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zones", "Condominium_Id", "dbo.Condominiums");
            DropIndex("dbo.Zones", new[] { "Condominium_Id" });
            DropColumn("dbo.Zones", "Condominium_Id");
        }
    }
}
