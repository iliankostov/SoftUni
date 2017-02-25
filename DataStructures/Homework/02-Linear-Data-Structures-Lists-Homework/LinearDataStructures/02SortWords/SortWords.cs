namespace LinearDataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new NullReferenceException("Input cannot be empty!");
                }

                IList<string> words = input.Split(' ').OrderBy(w => w).ToList();

                Console.WriteLine(string.Join(" ", words));
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
