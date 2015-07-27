namespace NewsDatabase
{
    using System.Data.Entity;

    using NewsDatabase.Migrations;

    public class NewsEntities : DbContext
    {
        public NewsEntities()
            : base("NewsEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<NewsEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public DbSet<News> News { get; set; }
    }
}