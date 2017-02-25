namespace OlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class OlympicsAreComing
    {
        private static void Main()
        {
            var line = Console.ReadLine();
            var data = new Dictionary<string, Dictionary<string, int>>();

            while (line != "report")
            {
                var lineArgs = line.Split('|');
                string name = string.Join(" ", lineArgs[0].Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries));
                string country = string.Join(
                    " ",
                    lineArgs[1].Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries));

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, int>();
                }

                if (!data[country].ContainsKey(name))
                {
                    data[country][name] = 0;
                }

                data[country][name]++;

                line = Console.ReadLine();
            }

            var sortedData = data.OrderByDescending(d => d.Value.Sum(w => w.Value));

            foreach (var country in sortedData)
            {
                Console.WriteLine(
                    "{0} ({1} participants): {2} wins",
                    country.Key,
                    country.Value.Count,
                    country.Value.Sum(w => w.Value));
            }
        }
    }
}