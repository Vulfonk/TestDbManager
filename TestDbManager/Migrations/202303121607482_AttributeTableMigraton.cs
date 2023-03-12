namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeTableMigraton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        objectid = c.Int(nullable: false),
                        name = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Objects", t => t.objectid, cascadeDelete: true)
                .Index(t => t.objectid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attributes", "objectid", "dbo.Objects");
            DropIndex("dbo.Attributes", new[] { "objectid" });
            DropTable("dbo.Attributes");
        }
    }
}
