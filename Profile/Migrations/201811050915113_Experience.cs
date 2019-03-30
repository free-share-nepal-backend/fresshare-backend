namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Experience : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        Post = c.String(nullable: false),
                        OfficeName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        OfficeDetails = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experiences");
        }
    }
}
