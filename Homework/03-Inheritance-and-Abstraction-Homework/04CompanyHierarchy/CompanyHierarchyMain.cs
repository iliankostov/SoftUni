namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    internal class CompanyHierarchyMain
    {
        internal static void Main()
        {
            try
            {
                List<Sale> sales = new List<Sale>()
                {
                    new Sale("Restaurant software", Convert.ToDateTime("01/08/2009"), 15000M),
                    new Sale("Cloth store software", Convert.ToDateTime("01/08/2010"), 20000M),
                    new Sale("Shoes software", Convert.ToDateTime("01/08/2011"), 17500M),
                    new Sale("Parking software", Convert.ToDateTime("01/08/2012"), 10000M),
                    new Sale("Building managment software", Convert.ToDateTime("01/08/2013"), 150500M)
                };

                List<SalesEmployee> salesEmployee = new List<SalesEmployee>()
                {
                    new SalesEmployee(2001, "Maria", "Hristova", 1575M, Department.Sales, sales),
                    new SalesEmployee(2001, "Ignat", "Minchev", 1550M, Department.Sales, sales),
                    new SalesEmployee(2001, "Boris", "Kitanov", 1600M, Department.Sales, sales)
                };

                List<Project> projects = new List<Project>()
                {
                    new Project("Restaurant software", Convert.ToDateTime("01/08/2008"), "Restaurant Pri Kmeta", ProjectState.Closed),
                    new Project("Cloth store software", Convert.ToDateTime("01/08/2009"), "Store Capasca", ProjectState.Closed),
                    new Project("Shoes software", Convert.ToDateTime("01/08/2010"), "Store Kolev i Kolev", ProjectState.Closed),
                    new Project("Parking software", Convert.ToDateTime("01/08/2011"), "Parking Mall Paradise", ProjectState.Closed),
                    new Project("Building managment software", Convert.ToDateTime("01/08/2012"), "BMS Paradise", ProjectState.Closed)       
                };
                Project carSoftware = new Project("Car software", Convert.ToDateTime("01/08/2013"), "Audi software", ProjectState.Open);
                carSoftware.CloseProject();
                projects.Add(carSoftware);

                List<Developer> developers = new List<Developer>()
                {
                    new Developer(3001, "Georgi", "Georgiev", 2200, Department.Production, projects),
                    new Developer(3002, "Kalin", "Mandaliev", 2500, Department.Production, projects)
                };

                List<RegularEmployee> workers = new List<RegularEmployee>();
                workers.AddRange(salesEmployee);
                workers.AddRange(developers);

                List<Manager> managers = new List<Manager>()
                {
                    new Manager(1001, "Ivan", "Ivanov", 3000M, Department.Sales, workers)
                };

                List<Employee> employees = new List<Employee>();
                employees.AddRange(managers);
                employees.AddRange(salesEmployee);
                employees.AddRange(developers);

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                    Console.WriteLine(new string('*', 60));
                }
            }
            catch (ArgumentNullException ane)
            {
                Console.Error.WriteLine("Error: " + ane.ParamName);
            }
            catch (ArgumentException ae)
            {
                Console.Error.WriteLine("Error: " + ae.Message);
            }           
        }
    }
}