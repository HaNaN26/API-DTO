namespace ITI.WebApiTask.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ITI.WebApiTask.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ITI.WebApiTask.Models.ITIWebApiTaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITI.WebApiTask.Models.ITIWebApiTaskContext context)
        {
            context.Employees.AddOrUpdate(x => x.dept_id,
       new Department() { dept_id = 1, dept_name = "Jane Austen" },
       new Department() { dept_id = 2, dept_name = "Charles Dickens" },
       new Department() { dept_id = 3, dept_name = "Miguel de Cervantes" }
       );

            context.Departments.AddOrUpdate(x => x.dtudent_id,
                new student()
                {
                    dtudent_id = 1,
                    student_Name="cs",
                    country="egypt",
                    city="cairo"
                },
                new student()
                {
                    dtudent_id = 2,
                    student_Name = "is",
                    country = "egypt",
                    city = "cairo"
                },
                new student()
                {
                    dtudent_id = 3,
                    student_Name = "it",
                    country = "egypt",
                    city = "cairo"
                },
               new student()
               {
                   dtudent_id = 4,
                   student_Name = "or",
                   country = "egypt",
                   city = "cairo"
               }
                );
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
        }
    }
}
