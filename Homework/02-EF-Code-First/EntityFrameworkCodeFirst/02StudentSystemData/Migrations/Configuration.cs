namespace EntityFrameworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkCodeFirst.StudentSystemEntity>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "EntityFrameworkCodeFirst.StudentSystemEntity";
        }

        protected override void Seed(StudentSystemEntity context)
        {
            var random = new Random();

            if (!context.Resources.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newResource = new Resource()
                    {
                        Name = "Resource" + i,
                        ResourceType = (ResourceType)random.Next(0, 4),
                        Url = "http://www.example.com/" + i
                    };

                    context.Resources.Add(newResource);
                }

                context.SaveChanges();
            }

            if (!context.Homeworks.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newNomework = new Homework
                    {
                        Content = "Content number " + i,
                        ContentType = (ContentType)random.Next(0, 2),
                        SubmissionDate = DateTime.Now.AddDays(i)
                    };

                    context.Homeworks.Add(newNomework);
                }

                context.SaveChanges();
            }

            if (!context.Students.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newStudent = new Student
                    {
                        Name = "Student" + i,
                        RegistrationDate = DateTime.Now.AddDays(i),
                        Homeworks = context.Homeworks.OrderBy(s => Guid.NewGuid()).Take(random.Next(0, 10)).ToList()
                    };

                    context.Students.Add(newStudent);
                }

                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newCourse = new Course()
                    {
                        Name = "Course" + i,
                        StartDate = DateTime.Now.AddDays(i),
                        EndDate = DateTime.Now.AddMonths(i),
                        Price = i * 100M,
                        Students = context.Students.OrderBy(s => Guid.NewGuid()).Take(random.Next(0, 10)).ToList(),
                        Resources = context.Resources.OrderBy(s => Guid.NewGuid()).Take(random.Next(0, 10)).ToList(),
                        Homeworks = context.Homeworks.OrderBy(s => Guid.NewGuid()).Take(random.Next(0, 10)).ToList()
                    };

                    context.Courses.Add(newCourse);
                }

                context.SaveChanges();
            }
        }
    }
}
