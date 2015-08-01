namespace Photography
{
    using System.Data.Entity;

    using Photography.Migrations;
    using Photography.Models;

    public class PhonebookEntities : DbContext
    {
        public PhonebookEntities()
            : base("name=PhonebookEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<PhonebookEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Channel> Channels { get; set; }

        public virtual DbSet<UserMessages> UserMessageses { get; set; }

        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessages>()
                .HasRequired(x => x.SenderUser)
                .WithMany(x => x.SendUserMessageses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMessages>()
                .HasRequired(x => x.RecipientUser)
                .WithMany(x => x.RecievedUserMessageses)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}