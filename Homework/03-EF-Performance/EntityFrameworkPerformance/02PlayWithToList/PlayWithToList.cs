namespace EntityFrameworkPerformance
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    public class PlayWithToList
    {
        public static void Main()
        {
            var context = new AdsEntities();
            //// Initialize connection
            var published = context.Ads.First().AdStatus.Status;
            TimeSpan[] nonOptimizedArray = new TimeSpan[6];
            TimeSpan[] optimizedArray = new TimeSpan[6];
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 6; i++)
            {
                sw.Restart();
                var adsBadWay = context.Ads
                    .ToList()
                    .Where(a => a.AdStatus.Status == published)
                    .Select(
                        a => new
                                 {
                                     a.Title,
                                     a.Category,
                                     a.Town,
                                     a.Date
                                 })
                    .ToList()
                    .OrderBy(a => a.Date);                   
                nonOptimizedArray[i] = sw.Elapsed;

                sw.Restart();
                var adsOptimized = context.Ads
                    .Where(a => a.AdStatus.Status == published)
                    .OrderBy(a => a.Date)
                    .Select(a => new
                    {
                        a.Title,
                        a.Category,
                        a.Town
                    });
                optimizedArray[i] = sw.Elapsed;
            }

            sw.Stop();

            string table = string.Format(
@"
                       Run 1              Run 2              Run 3              Run 4              Run 5              Run 6         Average time (ms)              
 --------------- ------------------ ------------------ ------------------ ------------------ ------------------ ------------------ ------------------- 
  Non-optimized   {0}   {1}   {2}   {3}   {4}   {5}   {6:F10}
  Optimized       {7}   {8}   {9}   {10}   {11}   {12}   {13:F10}
",
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

            Console.WriteLine("Find the output at table.txt");
        }
    }
}
