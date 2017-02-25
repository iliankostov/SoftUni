namespace PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class PopulationCounter
    {
        private static void Main()
        {
            string line = Console.ReadLine();

            var data = new Dictionary<string, Dictionary<string, long>>();

            while (line != "report")
            {
                string[] lineArgs = line.Split('|');
                string city = lineArgs[0];
                string country = lineArgs[1];
                long population = long.Parse(lineArgs[2]);

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, long>();
                }

                data[country].Add(city, population);

                line = Console.ReadLine();
            }

            var sortedPopulationData = data.OrderByDescending(d => d.Value.Sum(c => c.Value));

            foreach (var countryData in sortedPopulationData)
            {
                long totalPopulation = countryData.Value.Sum(c => c.Value);
                Console.WriteLine("{0} (total population: {1})", countryData.Key, totalPopulation);
                var sortedCityData = countryData.Value.OrderByDescending(c => c.Value);

                foreach (var city in sortedCityData)
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }
    }
}