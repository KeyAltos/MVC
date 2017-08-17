namespace ORM.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MigrateDB : DbMigration
    {
        public override void Down()
        {
            this.DropColumn("dbo.User", "LocationCity");
            this.DropColumn("dbo.User", "LocationCoutry");
            this.DropColumn("dbo.Author", "LocationCoutry");
        }

        public override void Up()
        {
            this.AddColumn("dbo.Author", "LocationCoutry", c => c.String());
            this.AddColumn("dbo.User", "LocationCoutry", c => c.String());
            this.AddColumn("dbo.User", "LocationCity", c => c.String());
        }
    }
}