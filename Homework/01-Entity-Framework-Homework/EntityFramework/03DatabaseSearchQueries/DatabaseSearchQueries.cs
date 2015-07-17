namespace EntityFramework
{
    using System;
    using System.Linq;

    class DatabaseSearchQueries
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            Console.Write("Select from 1 to 4: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DateTime startDate = Convert.ToDateTime("01/01/2001");
                    DateTime endDate = Convert.ToDateTime("31/12/2003");
                    var employees = context.Employees
                        .Where(e => e.Projects
                            .Any(p => p.StartDate >= startDate && p.EndDate <= endDate))
                        .Select(e => new
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            ManagerFirstName = e.Manager.FirstName,
                            ManagerLastName = e.Manager.LastName,
                            Projects = e.Projects.Select(p => new
                            {
                                ProjectName = p.Name,
                                StartDate = p.StartDate,
                                EndDate = p.EndDate
                            })
                        });

                    foreach (var employee in employees)
                    {
                        foreach (var project in employee.Projects)
                        {
                            Console.WriteLine("Employee: {0} {1}\nManager: {2} {3}\nProject: {4} - {5} - {6}\n",
                                employee.FirstName,
                                employee.LastName,
                                employee.ManagerFirstName,
                                employee.ManagerLastName,
                                project.ProjectName,
                                project.StartDate,
                                project.EndDate);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
        }
    }
}
