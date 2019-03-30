namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class education : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.String(nullable: false),
                        EndDate = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        CollegeName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        CollegeDetail = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Educations");
        }
    }
}
