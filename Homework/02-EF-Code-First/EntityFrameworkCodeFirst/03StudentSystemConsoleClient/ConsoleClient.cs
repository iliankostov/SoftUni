namespace EntityFrameworkCodeFirst
{
    using System.Data.Entity;

    using Migrations;

    public class ConsoleClient
    {
        public static void Main()
        {
            var context = new StudentSystemEntity();
            var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemEntity, Configuration>();
            Database.SetInitializer(migrationStrategy);

            //// TODO Problem 3 Working with the Database
        }
    }
}
