namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new NullReferenceException("Sum=0; Average=0");
                }

                IList<int> numbers = input.Split(' ').Select(int.Parse).ToList();

                Console.WriteLine("Sum={0}; Average={1}", numbers.Sum(), numbers.Average());
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
