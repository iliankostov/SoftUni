namespace Twitter.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Contracts;
    using Twitter.Data.Migrations;
    using Twitter.Models;

    public class TwitterContext : IdentityDbContext<User>, ITwitterContext
    {
        public TwitterContext()
            : base("name=TwitterContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Report> Reports { get; set; }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Followers).WithMany().Map(
                m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("FollowerId");
                        m.ToTable("UserFollowers");
                    });

            modelBuilder.Entity<User>().HasMany(u => u.Following).WithMany().Map(
                m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("FollowingId");
                        m.ToTable("UserFollowing");
                    });

            modelBuilder.Entity<Tweet>().HasMany(u => u.ReplyTweets).WithMany().Map(
                m =>
                    {
                        m.MapLeftKey("TweetId");
                        m.MapRightKey("ReplyTweetId");
                        m.ToTable("ReplyTweets");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}