namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCondominiumsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condominiums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubsidiaryId = c.Long(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Condominiums");
        }
    }
}
