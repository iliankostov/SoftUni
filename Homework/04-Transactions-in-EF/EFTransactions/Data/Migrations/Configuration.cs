namespace EFTransactions.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NewsEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Data.NewsEntities";
        }

        protected override void Seed(NewsEntities context)
        {
            if (!context.News.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var news = new News
                                   {
                                       NewsContent = "News number " + i
                                   };
                    context.News.Add(news);
                }

                context.SaveChanges();
            }
        }
    }
}
