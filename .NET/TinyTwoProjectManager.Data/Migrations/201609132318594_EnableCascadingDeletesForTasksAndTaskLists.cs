namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableCascadingDeletesForTasksAndTaskLists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskList", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "TaskListId", "dbo.TaskList");
            AddForeignKey("dbo.TaskList", "ProjectId", "dbo.Project", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Task", "TaskListId", "dbo.TaskList", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "TaskListId", "dbo.TaskList");
            DropForeignKey("dbo.TaskList", "ProjectId", "dbo.Project");
            AddForeignKey("dbo.Task", "TaskListId", "dbo.TaskList", "Id");
            AddForeignKey("dbo.TaskList", "ProjectId", "dbo.Project", "Id");
        }
    }
}
