namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceTaskListsAndProjectsWithTaskGroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskList", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Task", "TaskListId", "dbo.TaskList");
            DropForeignKey("dbo.Project", "UserId", "dbo.AppUser");
            DropIndex("dbo.Project", new[] { "UserId" });
            DropIndex("dbo.TaskList", new[] { "ProjectId" });
            DropIndex("dbo.Task", new[] { "TaskListId" });
            CreateTable(
                "dbo.TaskGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentTaskGroupId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false, defaultValue: DateTime.Now),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskGroup", t => t.ParentTaskGroupId, cascadeDelete: false)
                .ForeignKey("dbo.AppUser", t => t.UserId)
                .Index(t => t.ParentTaskGroupId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Task", "TaskGroupId", c => c.Int());
            CreateIndex("dbo.Task", "TaskGroupId");
            AddForeignKey("dbo.Task", "TaskGroupId", "dbo.TaskGroup", "Id", cascadeDelete: true);
            DropColumn("dbo.Task", "TaskListId");
            DropTable("dbo.Project");
            DropTable("dbo.TaskList");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaskList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Task", "TaskListId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TaskGroup", "UserId", "dbo.AppUser");
            DropForeignKey("dbo.Task", "TaskGroupId", "dbo.TaskGroup");
            DropForeignKey("dbo.TaskGroup", "ParentTaskGroupId", "dbo.TaskGroup");
            DropIndex("dbo.Task", new[] { "TaskGroupId" });
            DropIndex("dbo.TaskGroup", new[] { "UserId" });
            DropIndex("dbo.TaskGroup", new[] { "ParentTaskGroupId" });
            DropColumn("dbo.Task", "TaskGroupId");
            DropTable("dbo.TaskGroup");
            CreateIndex("dbo.Task", "TaskListId");
            CreateIndex("dbo.TaskList", "ProjectId");
            CreateIndex("dbo.Project", "UserId");
            AddForeignKey("dbo.Project", "UserId", "dbo.AppUser", "Id");
            AddForeignKey("dbo.Task", "TaskListId", "dbo.TaskList", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TaskList", "ProjectId", "dbo.Project", "Id", cascadeDelete: true);
        }
    }
}
