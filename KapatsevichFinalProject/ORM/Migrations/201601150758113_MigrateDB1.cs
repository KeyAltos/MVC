namespace ORM.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class MigrateDB1 : DbMigration
    {
        public override void Down()
        {
            this.AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }

        public override void Up()
        {
            this.AlterColumn("dbo.User", "FirstName", c => c.String());
        }
    }
}