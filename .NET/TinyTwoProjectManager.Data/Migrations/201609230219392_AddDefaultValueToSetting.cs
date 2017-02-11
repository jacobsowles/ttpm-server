namespace TinyTwoProjectManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValueToSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Setting", "DefaultValue", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Setting", "DefaultValue");
        }
    }
}
