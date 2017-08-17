namespace ORM.Migrations
{
    using System.Data.Entity.Migrations;

    using ORM.EntityModel;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityModel>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "ORM.EntityModel";
        }

        protected override void Seed(EntityModel context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
        }
    }
}