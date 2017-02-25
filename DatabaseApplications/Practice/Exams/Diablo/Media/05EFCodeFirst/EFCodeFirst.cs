namespace Movies
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Movies.Models;

    public class EFCodeFirst
    {
        public static void Main()
        {
            var context = new MoviesEntities();
            var js = new JavaScriptSerializer();

            ExportAdultMovies(context, js);

            ExportRatedMoviesByUser(context, js);

            ExportTopFavouriteMovies(context, js);
        }

        private static void ExportTopFavouriteMovies(MoviesEntities context, JavaScriptSerializer js)
        {
            var topTenFavouriteTeenMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .Select(m => new
                             {
                                 isbn = m.Isbn,
                                 title = m.Title,
                                 favouritedBy = m.Ratings.Count // no idea
                             })
                .OrderByDescending(m => m.favouritedBy)
                .ThenBy(m => m.title)
                .Take(10);

            var output = js.Serialize(topTenFavouriteTeenMovies);
            //File.AppendAllText(@"..\..\Results\top-10-favourite-movies.json", output);
            //Console.WriteLine("Export top-10-favourite-movies.json complited!");
        }

        private static void ExportRatedMoviesByUser(MoviesEntities context, JavaScriptSerializer js)
        {
            var ratedMoviesByUser = context.Users
                .Select(u => new
                             {
                                 username = u.Username,
                                 ratedMovies = u.Movies.Where(m => m.Ratings.Count > 0) // no idea
                             });

            var output = js.Serialize(ratedMoviesByUser);
            //File.AppendAllText(@"..\..\Results\rated-movies-by-jmeyery.json", output);
            //Console.WriteLine("Export rated-movies-by-jmeyery.json complited!");
        }

        private static void ExportAdultMovies(MoviesEntities context, JavaScriptSerializer js)
        {
            var allAdultMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .Select(m => new
                             {
                                 title = m.Title,
                                 ratingsGiven = m.Ratings.Count
                             })
                .OrderBy(m => m.title)
                .ThenBy(m => m.ratingsGiven);
            
            var output = js.Serialize(allAdultMovies);
            File.AppendAllText(@"..\..\Results\adult-movies.json", output);
            Console.WriteLine("Export adult-movies.json complited!");
        }
    }
}
