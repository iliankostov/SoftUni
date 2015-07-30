namespace ProcessingJSON
{
    using System;
    using System.Linq;

    public class ConsoleApp
    {
        public static void Main()
        {
            var context = new ProductShopEntities();
            Console.WriteLine(context.Users.Count());
            Console.WriteLine(context.Products.Count());
            Console.WriteLine(context.Categories.Count());
        }
    }
}
