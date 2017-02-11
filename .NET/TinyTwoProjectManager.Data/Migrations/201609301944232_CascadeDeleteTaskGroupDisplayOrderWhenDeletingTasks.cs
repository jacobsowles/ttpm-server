namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDeleteTaskGroupDisplayOrderWhenDeletingTasks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskGroupDisplayOrder", "TaskId", "dbo.Task");
            AddForeignKey("dbo.TaskGroupDisplayOrder", "TaskId", "dbo.Task", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskGroupDisplayOrder", "TaskId", "dbo.Task");
            AddForeignKey("dbo.TaskGroupDisplayOrder", "TaskId", "dbo.Task", "Id");
        }
    }
}
