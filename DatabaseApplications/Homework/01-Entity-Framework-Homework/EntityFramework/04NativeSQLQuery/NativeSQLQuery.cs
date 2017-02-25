using System.Diagnostics;

namespace EntityFramework
{
    using System;
    using System.Linq;

    public class NativeSQLQuery
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            // Estabish connection to server in advance
            var totalCount = context.Employees.Count();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            string query = @"
SELECT 
    e.FirstName
    FROM Employees AS e
    WHERE  EXISTS (SELECT 
        1
        FROM  EmployeesProjects AS ep
        INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID
        WHERE (e.EmployeeID = ep.EmployeeID) AND (2002 = (DATEPART (year, p.StartDate)))
    )";
            var employeesGetByNativeQuery = context.Database.SqlQuery<string>(query).ToArrayAsync().Result;
            foreach (var employeeN in employeesGetByNativeQuery)
            {
                //Console.WriteLine(employeeN);
            }
            Console.WriteLine("Native: {0}", sw.Elapsed);

            sw.Restart();
            var employeesGetByLinq = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year == 2002))
                .Select(e => new { e.FirstName });
            foreach (var employeeL in employeesGetByLinq)
            {
                //Console.WriteLine(employeeL.FirstName);
            }
            Console.WriteLine("Linq:   {0}", sw.Elapsed);
        }
    }
}
