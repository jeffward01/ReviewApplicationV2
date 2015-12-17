namespace ReviewApplication.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReviewApplication.Data.Infrastructure.ReviewApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //TODO: add data to database here using C#
        protected override void Seed(ReviewApplication.Data.Infrastructure.ReviewApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-3
            // http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx








        }
    }
}
