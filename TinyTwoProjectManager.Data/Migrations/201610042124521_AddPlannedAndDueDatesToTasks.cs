namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlannedAndDueDatesToTasks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "PlannedDate", c => c.DateTime());
            AddColumn("dbo.Task", "DueDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "DueDate");
            DropColumn("dbo.Task", "PlannedDate");
        }
    }
}
