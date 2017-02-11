namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSettingsAndUserSettingsTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        SettingId = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Setting", t => t.SettingId)
                .ForeignKey("dbo.AppUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SettingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSetting", "UserId", "dbo.AppUser");
            DropForeignKey("dbo.UserSetting", "SettingId", "dbo.Setting");
            DropIndex("dbo.UserSetting", new[] { "SettingId" });
            DropIndex("dbo.UserSetting", new[] { "UserId" });
            DropTable("dbo.UserSetting");
            DropTable("dbo.Setting");
        }
    }
}
