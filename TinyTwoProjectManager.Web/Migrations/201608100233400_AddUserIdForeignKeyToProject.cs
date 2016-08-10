namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdForeignKeyToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Project", "UserId");
            AddForeignKey("dbo.Project", "UserId", "dbo.AppUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project", "UserId", "dbo.AppUser");
            DropIndex("dbo.Project", new[] { "UserId" });
            DropColumn("dbo.Project", "UserId");
        }
    }
}
