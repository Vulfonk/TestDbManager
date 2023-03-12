namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Subject", newName: "Objects");
            RenameColumn(table: "dbo.Links", name: "ChildId", newName: "idchild");
            RenameColumn(table: "dbo.Links", name: "ParentId", newName: "idparent");
            RenameIndex(table: "dbo.Links", name: "IX_ChildId", newName: "IX_idchild");
            RenameIndex(table: "dbo.Links", name: "IX_ParentId", newName: "IX_idparent");
            AddColumn("dbo.Objects", "product", c => c.String());
            AddColumn("dbo.Objects", "type", c => c.String());
            DropColumn("dbo.Objects", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objects", "Name", c => c.String());
            DropColumn("dbo.Objects", "type");
            DropColumn("dbo.Objects", "product");
            RenameIndex(table: "dbo.Links", name: "IX_idparent", newName: "IX_ParentId");
            RenameIndex(table: "dbo.Links", name: "IX_idchild", newName: "IX_ChildId");
            RenameColumn(table: "dbo.Links", name: "idparent", newName: "ParentId");
            RenameColumn(table: "dbo.Links", name: "idchild", newName: "ChildId");
            RenameTable(name: "dbo.Objects", newName: "Subject");
        }
    }
}
