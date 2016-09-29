namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskGroupDisplayOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskGroupDisplayOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskGroupId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Task", t => t.TaskId)
                .ForeignKey("dbo.TaskGroup", t => t.TaskGroupId)
                .Index(t => t.TaskGroupId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskGroupDisplayOrder", "TaskGroupId", "dbo.TaskGroup");
            DropForeignKey("dbo.TaskGroupDisplayOrder", "TaskId", "dbo.Task");
            DropIndex("dbo.TaskGroupDisplayOrder", new[] { "TaskId" });
            DropIndex("dbo.TaskGroupDisplayOrder", new[] { "TaskGroupId" });
            DropTable("dbo.TaskGroupDisplayOrder");
        }
    }
}
