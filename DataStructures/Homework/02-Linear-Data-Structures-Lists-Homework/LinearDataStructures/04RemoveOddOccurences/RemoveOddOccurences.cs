namespace LinearDataStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RemoveOddOccurences
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

                IList<int> sequence = numbers.Where(v => numbers.Count(n => v == n) % 2 == 0).ToList();

                Console.WriteLine(string.Join(" ", sequence));
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
