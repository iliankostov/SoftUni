namespace EntityFramework
{
    using System.Data.Entity;

    public class EmployeeDAO
    {
        private static SoftUniEntities context = new SoftUniEntities();

        public static void Add(Employee employee)
        {
            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var employee = context.Employees.Find(key);

            return employee;
        }

        public static void Modify(Employee employee)
        {
            context.Employees.Attach(employee);

            var currentEmployee = context.Entry(employee);

            currentEmployee.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            context.Employees.Remove(employee);

            context.SaveChanges();
        }
    }
}
