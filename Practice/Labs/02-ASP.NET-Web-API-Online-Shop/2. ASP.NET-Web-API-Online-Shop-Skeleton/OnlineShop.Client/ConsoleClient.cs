namespace OnlineShop.Client
{
    using System;
    using System.Linq;
    using OnlineShop.Data;

    internal class ConsoleClient
    {
        private static void Main()
        {
            OnlineShopContext context = new OnlineShopContext();
            Console.WriteLine(context.Categories.Count());
        }
    }
}