namespace StacksAndQueues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbersWithAStack
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();

                if (input == "(empty)")
                {
                    throw new NullReferenceException("(empty)");
                }

                if (string.IsNullOrEmpty(input))
                {
                    throw new NullReferenceException("(empty)");
                }

                Stack<int> numbers = new Stack<int>();

                input.Split(' ').Select(int.Parse).ToList().ForEach(numbers.Push);

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
