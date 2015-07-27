namespace NewsDatabase
{
    using System;
    using System.Linq;

    public class NewsDatabase
    {
        public static void Main()
        {
            var context = new NewsEntities();
            var newsCount = context.News.Count();
            Console.WriteLine(newsCount);
        }
    }
}
