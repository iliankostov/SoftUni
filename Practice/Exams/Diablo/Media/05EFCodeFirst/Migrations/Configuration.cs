namespace Movies.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Movies.DTO;
    using Movies.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesEntities context)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (!context.Countries.Any() && !context.Users.Any() && !context.Movies.Any())
            {
                SeedCountries(context, js);

                SeedUsers(context, js);

                SeedMovies(context, js);

                SeedRatings(context, js);
            }
        }

        private static void SeedRatings(MoviesEntities context, JavaScriptSerializer js)
        {
            var ratingsJson = File.ReadAllText(@"..\..\Source\movie-ratings.json");

            var ratingsDto = js.Deserialize<List<MovieRatingsDTO>>(ratingsJson);

            foreach (var ratingDto in ratingsDto)
            {
                var rating = new Rating();

                rating.User = context.Users.FirstOrDefault(u => u.Username == ratingDto.User);
                rating.Movie = context.Movies.FirstOrDefault(m => m.Isbn == ratingDto.Movie);
                rating.Stars = int.Parse(ratingDto.Rating);

                context.Ratings.Add(rating);
            }

            context.SaveChanges();
        }

        private static void SeedMovies(MoviesEntities context, JavaScriptSerializer js)
        {
            var moviesJson = File.ReadAllText(@"..\..\Source\movies.json");

            var movies = js.Deserialize<List<Movie>>(moviesJson);

            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }

            context.SaveChanges();
        }

        private static void SeedCountries(MoviesEntities context, JavaScriptSerializer js)
        {
            var countriesJson = File.ReadAllText(@"..\..\Source\countries.json");

            var countries = js.Deserialize<List<Country>>(countriesJson);

            foreach (var country in countries)
            {
                context.Countries.Add(country);
            }
        }

        private static void SeedUsers(MoviesEntities context, JavaScriptSerializer js)
        {
            var usersJson = File.ReadAllText(@"..\..\Source\users.json");

            var usersDto = js.Deserialize<List<UserDTO>>(usersJson);

            foreach (var userDto in usersDto)
            {
                var user = new User();
                user.Username = userDto.Username;

                if (userDto.Age != null)
                {
                    user.Age = int.Parse(userDto.Age);
                }

                user.Email = userDto.Email;

                if (userDto.Country != null)
                {
                    user.Country = context.Countries.FirstOrDefault(c => c.Name == userDto.Country);
                }

                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
