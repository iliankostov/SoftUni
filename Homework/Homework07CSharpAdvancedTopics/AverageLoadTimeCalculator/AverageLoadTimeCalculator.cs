using System;
using System.Collections.Generic;
using System.Linq;


namespace AverageLoadTimeCalculator
{
    public class AverageLoadTimeCalculator
    {
        public static void Main()
        {                      
            string line = Console.ReadLine();
            Dictionary<string, double> dict = new Dictionary<string, double> { };
            while (line != string.Empty)
            {
                string[] list = line.Split(' ');
                string link = list[2];
                double loadTime = double.Parse(list[3]);
                if (!dict.Keys.Contains(link))
                {
                    dict[link] = loadTime;
                }
                else
                {
                    dict[link] = (dict[link] + loadTime) / 2;
                }
                line = Console.ReadLine();
            }
            foreach (string link in dict.Keys)
            {
                Console.WriteLine(link + " --> " + dict[link]);
            }
        }
    }
}