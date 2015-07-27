namespace NewsDatabase
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class ConcurrentUpdates
    {
        public static void Main()
        {
            var firstUser = new NewsEntities();
            var secondUser = new NewsEntities();

            try
            {
                Console.WriteLine("User one text from DB: " + firstUser.News.First().NewsContent);
                Console.WriteLine("User two text from DB: " + secondUser.News.First().NewsContent);

                Console.Write("User one enter the corected text: ");
                firstUser.News.First().NewsContent = Console.ReadLine();
                
                Console.Write("User two enter the corected text: ");
                secondUser.News.First().NewsContent = Console.ReadLine();

                firstUser.SaveChanges();
                Console.WriteLine("User One successfully saved in the DB.");

                secondUser.SaveChanges();
                Console.WriteLine("User Two successfully saved in the DB.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine("Conflict!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
