namespace ShmoogleCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class ShmoogleCounter
    {
        private static void Main()
        {
            string line = Console.ReadLine();
            string pattern = @"(double [a-zA-Z0-9]+|int [a-zA-Z0-9]+)";
            var regex = new Regex(pattern);
            List<string> doubles = new List<string>();
            List<string> ints = new List<string>();

            while (line != "//END_OF_CODE")
            {
                var matches = regex.Matches(line);
                foreach (Match match in matches)
                {
                    var matchArgs = match.Groups[1].Value.Split(' ');
                    if (matchArgs[0] == "double")
                    {
                        doubles.Add(matchArgs[1]);
                    }

                    if (matchArgs[0] == "int")
                    {
                        ints.Add(matchArgs[1]);
                    }
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("Doubles: {0}", doubles.Count > 0 ? string.Join(", ", doubles.OrderBy(d => d)) : "None");
            Console.WriteLine("Ints: {0}", ints.Count > 0 ? string.Join(", ", ints.OrderBy(d => d)) : "None");
        }
    }
}