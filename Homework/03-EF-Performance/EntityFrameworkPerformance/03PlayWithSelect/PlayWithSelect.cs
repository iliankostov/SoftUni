namespace EntityFrameworkPerformance
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class PlayWithSelect
    {
        public static void Main()
        {
            var context = new AdsEntities();
            //// Initialize connection
            Console.WriteLine("All ads = " + context.Ads.Count());
            string clearCache = "CHECKPOINT; DBCC DROPCLEANBUFFERS;";
            TimeSpan[] nonOptimizedArray = new TimeSpan[6];
            TimeSpan[] optimizedArray = new TimeSpan[6];

            for (int i = 0; i < 6; i++)
            {
                Stopwatch sw = new Stopwatch();
                context.Database.ExecuteSqlCommand(clearCache);

                sw.Start();
                foreach (var ad in context.Ads)
                {
                    Console.WriteLine(ad.Title);
                }

                nonOptimizedArray[i] = sw.Elapsed;

                context.Database.ExecuteSqlCommand(clearCache);

                sw.Restart();
                foreach (var adTitle in context.Ads.Select(a => a.Title))
                {
                    Console.WriteLine(adTitle);
                }

                optimizedArray[i] = sw.Elapsed;
                sw.Stop();
            }

            string table = string.Format(
@"
                       Run 1              Run 2              Run 3              Run 4              Run 5              Run 6         Average time (ms)              
 --------------- ------------------ ------------------ ------------------ ------------------ ------------------ ------------------ ------------------- 
  Non-optimized   {0}   {1}   {2}   {3}   {4}   {5}   {6:F3}
  Optimized       {7}   {8}   {9}   {10}   {11}   {12}   {13:F3}",
            nonOptimizedArray[0],
            nonOptimizedArray[1],
            nonOptimizedArray[2],
            nonOptimizedArray[3],
            nonOptimizedArray[4],
            nonOptimizedArray[5],
            nonOptimizedArray.Average(n => n.Milliseconds),
            optimizedArray[0],
            optimizedArray[1],
            optimizedArray[2],
            optimizedArray[3],
            optimizedArray[4],
            optimizedArray[5],
            optimizedArray.Average(o => o.Milliseconds));
            File.WriteAllText(@"..\..\table.txt", table);

            Console.WriteLine("\nFind the output at table.txt");
        }
    }
}
