namespace LinearDataStructures
{
    using System;
    using System.Linq;

    public class CountOfOccurences
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

                var groups = input.Split(' ').Select(int.Parse).OrderBy(n => n).GroupBy(n => n);

                foreach (var grp in groups)
                {
                    Console.WriteLine("{0} -> {1} times", grp.Key, grp.Count());
                }
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
