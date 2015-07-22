namespace EntityFrameworkPerformance
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;

    public class ShowDataFromRelatedTables
    {
        public static void Main()
        {
            var context = new AdsEntities();

            Console.Write("Do you want to use Include() y/n: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "n":
                    var adsOne = context.Ads
                    .Select(a => new
                                 {
                                     Title = a.Title,
                                     Status = a.AdStatus.Status,
                                     Category = a.Category.Name,
                                     Town = a.Town.Name,
                                     User = a.AspNetUser.Name
                                 });
                    foreach (var ad in adsOne)
                    {
                        Console.WriteLine(
                            "Title: {0}\nStatus: {1}\nCategory: {2}\nTown: {3}\nUser: {4}", 
                            ad.Title,
                            ad.Status,
                            ad.Category,
                            ad.Town,
                            ad.User);
                    }

                    break;
                case "y":
                    var adsTwo = context.Ads
                        .Include(a => a.AdStatus)
                        .Include(a => a.Category)
                        .Include(a => a.Town)
                        .Include(a => a.AspNetUser);

                    foreach (var ad in adsTwo)
                    {
                        Console.WriteLine(
                            "Title: {0}\nStatus: {1}\nCategory: {2}\nTown: {3}\nUser: {4}",
                            ad.Title,
                            ad.AdStatus.Status,
                            ad.Category,
                            ad.Town,
                            ad.AspNetUser);
                    }

                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }

            string table = @"
                                                         No Include(…)   With Include(…)  
                             -------------------------- --------------- ----------------- 
                              Number of SQL statements               1                 1  ";
            File.WriteAllText(@"..\..\table.txt", table);
        }
    }
}
