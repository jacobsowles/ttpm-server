namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayOrderToTasks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "DisplayOrder");
        }
    }
}
