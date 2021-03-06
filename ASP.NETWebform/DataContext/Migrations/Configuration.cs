using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace DataContext
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext.StuDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext.StuDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            DepartMentSeed.Seed(context);
            context.SaveChanges();
            StudentSeed.Seed(context);
            context.SaveChanges();
        }
    }
}
