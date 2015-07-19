namespace EntityFramework
{
    using System;
    using System.Linq;

    public class NativeSQLQuery
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            DateTime startDate = Convert.ToDateTime("01/01/2002");
            DateTime endDate = Convert.ToDateTime("31/12/2002");

            var employeesGetByLinq = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate >= startDate && p.EndDate <= endDate))
                .Select(e => new { FirstName = e.FirstName});

            Console.WriteLine(startDate);
            Console.WriteLine(endDate);
            Console.WriteLine("Number of employees get by Linq: " + employeesGetByLinq.Count());

            string query = @"
SELECT Count(e.FirstName)
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE YEAR(p.StartDate) = '2002'";

            var employeesGetByNativeQuery = context.Database.SqlQuery<int>(query);

            Console.WriteLine("Number of employees get by native query: " + employeesGetByNativeQuery.Count());
        }
    }
}
