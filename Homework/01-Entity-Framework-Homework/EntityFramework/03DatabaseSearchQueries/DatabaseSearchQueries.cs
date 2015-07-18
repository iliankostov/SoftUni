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
                case "2":
                    var addresses = context.Addresses
                        .OrderByDescending(a => a.Employees.Count)
                        .ThenBy(a => a.Town.Name)
                        .Take(10)
                        .Select(a => new
                        {
                            AddressText = a.AddressText,
                            Town = a.Town.Name,
                            EmployeeCount = a.Employees.Count
                        });

                    foreach (var address in addresses)
                    {
                        Console.WriteLine("{0}, {1} - {2} employees", 
                            address.AddressText,
                            address.Town,
                            address.EmployeeCount);
                    }
                    break;
                case "3":
                    var emp = context.Employees
                        .Select(e => new
                        {
                            ID = e.EmployeeID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobTitle = e.JobTitle,
                            Projects = e.Projects.OrderBy(p => p.Name).Select(p => new { Name = p.Name })
                        })
                        .FirstOrDefault(e => e.ID == 147);

                    Console.WriteLine("{0} - {1} - {2} - Projects:",
                        emp.FirstName,
                        emp.LastName,
                        emp.JobTitle);
                    foreach (var project in emp.Projects)
                    {
                        Console.WriteLine(project.Name);
                    }

                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
        }
    }
}
