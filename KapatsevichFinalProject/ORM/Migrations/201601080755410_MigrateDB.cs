namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "LocationCoutry", c => c.String());
            AddColumn("dbo.User", "LocationCoutry", c => c.String());
            AddColumn("dbo.User", "LocationCity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "LocationCity");
            DropColumn("dbo.User", "LocationCoutry");
            DropColumn("dbo.Author", "LocationCoutry");
        }
    }
}
