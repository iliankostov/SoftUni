namespace Movies
{
    using System.Data.Entity;

    using Movies.Migrations;
    using Movies.Models;

    public class MoviesEntities : DbContext
    {
        public MoviesEntities()
            : base("MoviesEntities")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<MoviesEntities, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<User> Users { get; set; }
    }
}