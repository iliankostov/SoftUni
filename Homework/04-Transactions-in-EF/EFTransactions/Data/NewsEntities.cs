namespace EFTransactions
{
    using System.Data.Entity;

    public class NewsEntities : DbContext
    {
        public NewsEntities()
            : base("NewsEntities")
        {
        }

        public DbSet<News> News { get; set; }
    }
}