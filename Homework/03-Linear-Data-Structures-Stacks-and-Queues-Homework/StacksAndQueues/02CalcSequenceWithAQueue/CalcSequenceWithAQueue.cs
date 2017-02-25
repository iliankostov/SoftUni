namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CalcSequenceWithAQueue
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new NullReferenceException("The input cannot be empty.");
                }

                int n = int.Parse(input);

                Queue<int> numbers = new Queue<int>();
                numbers.Enqueue(n);

                int index = 0;
                while (numbers.Count < 50)
                {
                    int current = numbers.ElementAt(index);
                    index++;
                    numbers.Enqueue(current + 1);
                    numbers.Enqueue((2 * current) + 1);
                    numbers.Enqueue(current + 2);
                }

                Console.WriteLine(string.Join(" ", numbers));
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
