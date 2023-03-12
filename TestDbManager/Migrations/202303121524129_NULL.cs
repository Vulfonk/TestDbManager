namespace TestDbManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NULL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subject", "Name");
        }
    }
}
