namespace SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SrabskoUnleashed
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            var data = new Dictionary<string, Dictionary<string, decimal>>();

            while (line != "End")
            {
                var lineArgs = line.Split('@');
                if (lineArgs.Length == 2)
                {
                    var singer = lineArgs[0];
                    var lastIndex = singer.Length - 1;
                    if (singer[lastIndex] == ' ')
                    {
                        singer = singer.Trim();
                        var otherArgs = lineArgs[1].Split(' ');
                        if (otherArgs.Length >= 3)
                        {
                            decimal price = decimal.Parse(otherArgs[otherArgs.Length - 1]);
                            int tickets = int.Parse(otherArgs[otherArgs.Length - 2]);
                            var place = string.Join(" ", otherArgs, 0, otherArgs.Length - 2);

                            if (!data.ContainsKey(place))
                            {
                                data[place] = new Dictionary<string, decimal>();
                            }

                            if (!data[place].ContainsKey(singer))
                            {
                                data[place][singer] = 0;
                            }

                            data[place][singer] += tickets * price;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var keyValuePair in data)
            {
                Console.WriteLine(keyValuePair.Key);

                var sortedSingers = keyValuePair.Value.OrderByDescending(s => s.Value);

                foreach (var singer in sortedSingers)
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }
    }
}