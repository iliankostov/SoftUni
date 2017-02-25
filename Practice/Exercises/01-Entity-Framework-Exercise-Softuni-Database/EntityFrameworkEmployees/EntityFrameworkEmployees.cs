namespace EntityFrameworkEmployees
{
    using System;
    using System.Linq;

    public class EntityFrameworkEmployees
    {
        public static void Main()
        {
            var db = new SoftUniEntities();

            //// Problem 3. Employee Queries
            //// Step 1 - Employees with Salary Over 50 000
            //var employeeNames = db.Employees
            //    .Where(employee => employee.Salary > 50000)
            //    .Select(employee => employee.FirstName);

            //foreach (var employeeName in employeeNames)
            //{
            //    Console.WriteLine(employeeName);
            //}

            //// Step 2 - Employees from Research and Development department
            //var employees =
            //    db.Employees.Where(employee => employee.Department.Name == "Research and Development")
            //        .OrderBy(employee => employee.Salary)
            //        .ThenByDescending(employee => employee.FirstName)
            //        .Select(employee => new
            //                                {
            //                                    FirstName = employee.FirstName,
            //                                    LastName = employee.LastName,
            //                                    DepartmentName = employee.Department.Name,
            //                                    Salary = employee.Salary
            //                                });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} from {2} - ${3:F2}", employee.FirstName, employee.LastName, employee.DepartmentName, employee.Salary);
            //}

            //// Problem 4.	Adding a New Address and Updating Employee
            //var address = new Address()
            //                  {
            //                      AddressText = "Vitoshka 15",
            //                      TownID = 4
            //                  };

            //Employee nakov = db.Employees.FirstOrDefault(employee => employee.LastName == "Nakov");

            //if (nakov != null)
            //{
            //    nakov.Address = address;
            //    db.SaveChanges();
            //}

            //var nakovAddress = db.Employees.FirstOrDefault(employee => employee.LastName == "Nakov");
            //if (nakovAddress != null)
            //{
            //    Console.WriteLine(nakovAddress.Address.AddressText);
            //}

            //// Problem 5.	Deleting Project by Id
            //var project = db.Projects.Find(2);

            //if (project != null)
            //{
            //    var employees = db.Employees
            //    .Where(employee => employee.Projects
            //        .Any(p => p.ProjectID == project.ProjectID))
            //        .ToList();

            //    foreach (var employee in employees)
            //    {
            //        employee.Projects.Remove(project);
            //    }

            //    db.Projects.Remove(project);

            //    db.SaveChanges();
            //}
        }
    }
}
