namespace ProductsInPriceRange
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    internal class ProductsInPriceRange
    {
        private static void Main()
        {
            var random = new Random();
            var stopwatch = new Stopwatch();
            var output = new StringBuilder();
            var productsBag = new OrderedBag<Product>();

            stopwatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                productsBag.Add(new Product("product " + i, RandomPrice(random)));
            }

            var inputTime = stopwatch.Elapsed;

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                var randomPrice = RandomPrice(random);
                var productMinPrice = new Product("min", randomPrice);
                var productMaxPrice = new Product("max", randomPrice + 1m);
                var productsInPriceRange = productsBag.Range(productMinPrice, true, productMaxPrice, true).Take(20);

                foreach (var product in productsInPriceRange)
                {
                    output.AppendFormat("{0} -> {1:F2}", product.Name, product.Price).AppendLine();
                }

                output.AppendLine(new string('-', 30));
            }

            var outputTime = stopwatch.Elapsed;

            stopwatch.Restart();
            Console.WriteLine(output);
            var printTime = stopwatch.Elapsed;
            stopwatch.Stop();

            Console.WriteLine("Time for insert 500 000 products: " + inputTime);
            Console.WriteLine("Time for perform 10 000 searches: " + outputTime);
            Console.WriteLine("Time for print output to console: " + printTime);
        }

        private static decimal RandomPrice(Random random)
        {
            double fromTo = 100 + (random.NextDouble() * (10000 - 100));
            return (decimal)Math.Round(fromTo, 2);
        }
    }
}