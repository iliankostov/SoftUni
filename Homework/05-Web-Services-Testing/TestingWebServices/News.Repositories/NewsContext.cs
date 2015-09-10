namespace News.Repositories
{
    using System.Data.Entity;
    using News.Models;
    using News.Repositories.Migrations;

    public class NewsContext : DbContext
    {
        public NewsContext()
            : base("name=NewsContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<NewsContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<NewsItem> NewsItems { get; set; }
    }
}