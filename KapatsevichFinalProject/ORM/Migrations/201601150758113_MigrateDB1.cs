namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
