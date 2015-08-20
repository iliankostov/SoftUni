namespace Data
{
    using System.Data.Entity;

    using Data.Migrations;

    using Models;

    public class BookShopContext : DbContext, IBookShopContext
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                    {
                        m.MapLeftKey("BookId");
                        m.MapRightKey("RelatedId");
                        m.ToTable("RelatedBooks");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}