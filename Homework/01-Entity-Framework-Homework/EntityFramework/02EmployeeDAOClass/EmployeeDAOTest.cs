namespace EntityFramework
{
    using System;

    public class EmployeeDAOTest
    {
        public static void Main()
        {
            var ivan = new Employee
                              {
                                  FirstName = "Ivan",
                                  LastName = "Ivanov",
                                  MiddleName = "I",
                                  JobTitle = "Production Technician",
                                  DepartmentID = 7,
                                  HireDate = DateTime.Now,
                                  Salary = 30000
                              };

            EmployeeDAO.Add(ivan);
            Console.WriteLine("Successfully add {0} with ID = {1}", ivan.FirstName, ivan.EmployeeID);

            ivan.FirstName = "Ivancho";
            EmployeeDAO.Modify(ivan);
            Console.WriteLine("Successfully change first name to {0}", ivan.FirstName);

            EmployeeDAO.Delete(ivan);
            Console.WriteLine("Successfully delete {0} with Id = {1}", ivan.FirstName, ivan.EmployeeID);
        }
    }
}
