namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Client_Info : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client_Info",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        occupation = c.String(nullable: false),
                        phone = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Client_Info");
        }
    }
}
