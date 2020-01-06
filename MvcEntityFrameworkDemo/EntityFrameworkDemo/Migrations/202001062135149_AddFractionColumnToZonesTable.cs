namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFractionColumnToZonesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fractions", "Zone_Id", c => c.Int());
            CreateIndex("dbo.Fractions", "Zone_Id");
            AddForeignKey("dbo.Fractions", "Zone_Id", "dbo.Zones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fractions", "Zone_Id", "dbo.Zones");
            DropIndex("dbo.Fractions", new[] { "Zone_Id" });
            DropColumn("dbo.Fractions", "Zone_Id");
        }
    }
}
