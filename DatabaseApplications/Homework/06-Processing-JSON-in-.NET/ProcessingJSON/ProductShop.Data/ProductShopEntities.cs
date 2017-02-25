namespace ProcessingJSON
{
    using System.Data.Entity;

    using ProcessingJSON.Migrations;

    public class ProductShopEntities : DbContext
    {
        public ProductShopEntities()
            : base("ProductShopEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<ProductShopEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("FriendId");
                        m.ToTable("UserFriends");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}