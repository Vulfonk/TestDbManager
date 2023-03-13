namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_AttributeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attributes", "objectid", "dbo.Objects");
            DropIndex("dbo.Attributes", new[] { "objectid" });
            AlterColumn("dbo.Attributes", "objectid", c => c.Int());
            CreateIndex("dbo.Attributes", "objectid");
            AddForeignKey("dbo.Attributes", "objectid", "dbo.Objects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attributes", "objectid", "dbo.Objects");
            DropIndex("dbo.Attributes", new[] { "objectid" });
            AlterColumn("dbo.Attributes", "objectid", c => c.Int(nullable: false));
            CreateIndex("dbo.Attributes", "objectid");
            AddForeignKey("dbo.Attributes", "objectid", "dbo.Objects", "Id", cascadeDelete: true);
        }
    }
}
