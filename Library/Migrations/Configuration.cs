using System.Web.UI.WebControls;
using Library.Models;

namespace Library.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Library.Models.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            context.Subjects.AddOrUpdate(s => s.SubjectName,
                new Subject() { SubjectName = "Przygodowe", SubjectID = 1},
                new Subject() { SubjectName = "Horrory", SubjectID = 2 },
                new Subject() { SubjectName = "Powieści", SubjectID = 3 },
                new Subject() { SubjectName = "Romanse", SubjectID = 4 },
                new Subject() { SubjectName = "Fantastyka", SubjectID = 5 },
                new Subject() { SubjectName = "Biografia", SubjectID = 6 }
            );

           
        }
    }
}
