namespace EntityFramework
{
    public class ConcurrentDatabaseChanges
    {
        public static void Main()
        {
            var contextOne = new SoftUniEntities();
            var contextTwo = new SoftUniEntities();

            var employee = contextOne.Employees.Find(1);
            employee.FirstName = "Pesho";

            var theSameEmployee = contextTwo.Employees.Find(1);
            theSameEmployee.FirstName = "Gosho";

            contextOne.SaveChanges();
            contextTwo.SaveChanges();

            //// If [Concurrency Mode] is None the result is "Gosho"
            //// If [Concurrency Mode] is Fixed the result is "Pesho"
        }
    }
}
