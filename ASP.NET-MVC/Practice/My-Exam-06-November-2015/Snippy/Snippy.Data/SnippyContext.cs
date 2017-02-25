namespace Snippy.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Snippy.Data.Contracts;
    using Snippy.Models;

    public class SnippyContext : IdentityDbContext<User>, ISnippyContext
    {
        public SnippyContext()
            : base("name=SnippyContext")
        {
        }

        public virtual IDbSet<Snippet> Snippets { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Language> Languages { get; set; }

        public virtual IDbSet<Label> Labels { get; set; }

        public static SnippyContext Create()
        {
            return new SnippyContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>()
                        .HasRequired(s => s.Author)
                        .WithMany(u => u.Snippets)
                        .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}