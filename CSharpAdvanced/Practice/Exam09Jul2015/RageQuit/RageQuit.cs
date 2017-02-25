namespace RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class RageQuit
    {
        private static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(\D+)(\d+)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            var result = new StringBuilder();
            foreach (Match match in matches)
            {
                var currentResult = new StringBuilder();
                string message = match.Groups[1].Value.ToUpper();
                int number = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < number; i++)
                {
                    currentResult.Append(message);
                }

                result.Append(currentResult);
            }

            int count = result.ToString().Distinct().Count();

            Console.WriteLine("Unique symbols used: {0}", count);
            Console.WriteLine(result);
        }
    }
}