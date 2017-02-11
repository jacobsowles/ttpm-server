namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDefaultValuesForTaskComplete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Task", "Complete");
            AddColumn("dbo.Task", "Complete", c => c.Boolean(nullable: false, defaultValue: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Task", "Complete");
            AddColumn("dbo.Task", "Complete", c => c.Boolean(nullable: false));
        }
    }
}
