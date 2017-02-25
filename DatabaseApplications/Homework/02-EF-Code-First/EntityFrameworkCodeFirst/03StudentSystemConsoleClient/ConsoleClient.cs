namespace EntityFrameworkCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    using Migrations;

    public class ConsoleClient
    {
        public static void Main()
        {
            var context = new StudentSystemEntity();
            var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>();
            Database.SetInitializer(migrationStrategy);

            Console.Write("Please choise from 1 to 5: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var studentsWithHomeworks = context.Students
                        .Select(s => new 
                                    { 
                                        Name = s.Name, 
                                        Homeworks = s.Homeworks.Select(h => new
                                                                            {
                                                                                Content = h.Content,
                                                                                ContentType = h.ContentType
                                                                            })
                                    });
                    foreach (var student in studentsWithHomeworks)
                    {
                        Console.WriteLine("Student: " + student.Name);
                        foreach (var homework in student.Homeworks)
                        {
                            Console.WriteLine("Homework: {0} - {1}", homework.Content, homework.ContentType);
                        }
                    }

                    break;
                case "2":
                    var coursesWithResources = context.Courses
                        .OrderBy(c => c.StartDate)
                        .ThenByDescending(c => c.EndDate)
                        .Select(c => new
                                    {
                                        Name = c.Name,
                                        Description = c.Description,
                                        Resources = c.Resources.Select(r => new
                                                                            {
                                                                                Name = r.Name,
                                                                                Type = r.ResourceType,
                                                                                Url = r.Url
                                                                            })
                                    });
                    foreach (var course in coursesWithResources)
                    {
                        Console.WriteLine("Course: {0} {1}", course.Name, course.Description);
                        foreach (var resource in course.Resources)
                        {
                            Console.WriteLine("Resource: {0} {1} {2}", resource.Name, resource.Type, resource.Url);
                        }
                    }

                    break;
                case "3":
                    var coursesWithMoreThenFiveResources = context.Courses
                        .Where(c => c.Resources.Count > 5)
                        .OrderByDescending(c => c.Resources.Count)
                        .ThenByDescending(c => c.StartDate)
                        .Select(
                            c => new
                                {
                                    Name = c.Name,
                                    ResourceCount = c.Resources.Count
                                });
                    if (coursesWithMoreThenFiveResources.Any())
                    {
                        foreach (var course in coursesWithMoreThenFiveResources)
                        {
                            Console.WriteLine("{0} has {1} resources", course.Name, course.ResourceCount);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no courses with more than 5 resources.");
                    }

                    break;
                case "4":
                    var givenDate = Convert.ToDateTime("24/07/2015");
                    var activeCourses = context.Courses
                        .Where(c => c.StartDate <= givenDate && c.EndDate >= givenDate)
                        .Select(c => new
                                     {
                                         Name = c.Name,
                                         StartDate = c.StartDate,
                                         EndDate = c.EndDate,
                                         Duration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate),
                                         NumberOfStudents = c.Students.Count
                                     })
                        .OrderByDescending(c => c.NumberOfStudents)
                        .ThenByDescending(c => c.Duration);
                    foreach (var activeCourse in activeCourses)
                    {
                        Console.WriteLine(
                            "Course: {0}\nStart Date: {1}\nEnd Date: {2}\nDuration: {3} days\nNumber of students: {4}",
                            activeCourse.Name,
                            activeCourse.StartDate,
                            activeCourse.EndDate,
                            activeCourse.Duration,
                            activeCourse.NumberOfStudents);
                    }

                    break;
                case "5":
                    var students = context.Students
                        .Select(s => new
                                    {
                                        Name = s.Name,
                                        NumberOfCourses = s.Courses.Count,
                                        TotalPrice = s.Courses.Sum(c => c.Price),
                                        AveragePrice = s.Courses.Average(c => c.Price)
                                    })
                        .OrderByDescending(s => s.TotalPrice)
                        .ThenByDescending(s => s.NumberOfCourses)
                        .ThenBy(s => s.Name);
                    foreach (var student in students)
                    {
                        Console.WriteLine(
                            "Student: {0}\nNumber of cources: {1}\nTotal price: {2:C}\nAveragePrice: {3:C}",
                            student.Name,
                            student.NumberOfCourses,
                            student.TotalPrice,
                            student.AveragePrice);
                    }

                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }

            //// Add some licenses if not exists
            for (int i = 0; i < 20; i++)
            {
                var newLicense = new License()
                {
                    Name = "License" + i,
                };

                context.Licenses.AddOrUpdate(l => l.Name, newLicense);
            }

            context.SaveChanges();

            //// Attach some licenses to each resource
            int licenseOneId = 1;
            int licenseTwoId = 11;

            foreach (var resource in context.Resources)
            {
                var licenseOne = context.Licenses.FirstOrDefault(l => l.Id == licenseOneId);
                var licenseTwo = context.Licenses.FirstOrDefault(l => l.Id == licenseTwoId);
                resource.Licenses.Add(licenseOne);
                resource.Licenses.Add(licenseTwo);
                licenseOneId++;
                licenseTwoId++;
            }

            context.SaveChanges();
        }
    }
}
