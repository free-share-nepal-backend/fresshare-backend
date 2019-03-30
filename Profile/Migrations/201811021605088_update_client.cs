namespace Profile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_client : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client_Info", "status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client_Info", "status");
        }
    }
}
