namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new NullReferenceException("Sequence cannot be empty!");
                }

                IList<int> numbers = input.Split(' ').Select(int.Parse).ToList();

                IList<int> maxSequence = numbers
                    .Select((n, i) => new { Value = n, Index = i })
                    .OrderBy(s => s.Value)
                    .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
                    .GroupBy(s => new { s.Value, s.Diff })
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Select(f => f.Value)
                    .ToList();

                Console.WriteLine(string.Join(" ", maxSequence));
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
