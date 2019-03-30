namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class About_ME : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About_Me",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Introduction = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.About_Me");
        }
    }
}
