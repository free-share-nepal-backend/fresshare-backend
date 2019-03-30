namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_info1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Info",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User_Info");
        }
    }
}
