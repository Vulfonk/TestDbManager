namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChildId = c.Int(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.ChildId)
                .ForeignKey("dbo.Subject", t => t.ParentId)
                .Index(t => t.ChildId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ParentId", "dbo.Subject");
            DropForeignKey("dbo.Links", "ChildId", "dbo.Subject");
            DropIndex("dbo.Links", new[] { "ParentId" });
            DropIndex("dbo.Links", new[] { "ChildId" });
            DropTable("dbo.Subject");
            DropTable("dbo.Links");
        }
    }
}
