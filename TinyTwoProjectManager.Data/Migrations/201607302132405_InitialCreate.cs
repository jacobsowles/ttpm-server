using System.Data.Entity.Migrations;

namespace TinyTwoProjectManager.Data.Migrations
{
    public class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectLists",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Projects",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProjectListId = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectLists", t => t.ProjectListId, cascadeDelete: true)
                .Index(t => t.ProjectListId);

            CreateTable(
                "dbo.TaskLists",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProjectId = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);

            CreateTable(
                "dbo.Tasks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TaskListId = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskListId, cascadeDelete: true)
                .Index(t => t.TaskListId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists");
            DropForeignKey("dbo.TaskLists", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectListId", "dbo.ProjectLists");
            DropIndex("dbo.Tasks", new[] { "TaskListId" });
            DropIndex("dbo.TaskLists", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ProjectListId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskLists");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectLists");
        }
    }
}