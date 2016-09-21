namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdColumnToTasks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Task", "UserId");
            AddForeignKey("dbo.Task", "UserId", "dbo.AppUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "UserId", "dbo.AppUser");
            DropIndex("dbo.Task", new[] { "UserId" });
            DropColumn("dbo.Task", "UserId");
        }
    }
}
