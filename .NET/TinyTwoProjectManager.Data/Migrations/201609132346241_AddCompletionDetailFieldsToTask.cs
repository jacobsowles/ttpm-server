namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompletionDetailFieldsToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "FirstDateCompleted", c => c.DateTime(nullable: true));
            AddColumn("dbo.Task", "LastDateCompleted", c => c.DateTime(nullable: true));
            AddColumn("dbo.Task", "TimesCompleted", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "TimesCompleted");
            DropColumn("dbo.Task", "LastDateCompleted");
            DropColumn("dbo.Task", "FirstDateCompleted");
        }
    }
}
