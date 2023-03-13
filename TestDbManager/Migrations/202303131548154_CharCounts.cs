namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharCounts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Links", "type", c => c.String(maxLength: 50));
            AlterColumn("dbo.Attributes", "name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Attributes", "Value", c => c.String(maxLength: 150));
            AlterColumn("dbo.Objects", "product", c => c.String(maxLength: 150));
            AlterColumn("dbo.Objects", "type", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Objects", "type", c => c.String());
            AlterColumn("dbo.Objects", "product", c => c.String());
            AlterColumn("dbo.Attributes", "Value", c => c.String());
            AlterColumn("dbo.Attributes", "name", c => c.String());
            DropColumn("dbo.Links", "type");
        }
    }
}
