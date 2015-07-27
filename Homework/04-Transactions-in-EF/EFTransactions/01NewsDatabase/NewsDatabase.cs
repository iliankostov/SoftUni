namespace EFTransactions
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using EFTransactions.Migrations;

    public class NewsDatabase
    {
        public static void Main()
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<NewsEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);

            var context = new NewsEntities();
            var newsCount = context.News.Count();
            Console.WriteLine(newsCount);
        }
    }
}
