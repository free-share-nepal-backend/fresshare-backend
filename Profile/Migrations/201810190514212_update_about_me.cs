namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_about_me : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.About_Me", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.About_Me", "Status", c => c.String(nullable: false));
        }
    }
}
