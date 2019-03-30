namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class work : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Works", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Works", "Status", c => c.String(nullable: false));
        }
    }
}
