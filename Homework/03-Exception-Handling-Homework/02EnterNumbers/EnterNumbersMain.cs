namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    internal class EnterNumbersMain
    {
        internal static void Main()
        {
            int start = 0;
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 10; i++)
            {               
                try
                { 
                    numbers.Add(ReadNumber(start, 100));    
                    start = numbers[numbers.Count - 1];
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid integer number.");
                    i--;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Your number is not in range.");
                    i--;
                }
            }

            Console.Write("Your list is: ");
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        private static int ReadNumber(int start, int end)
        {
            Console.Write("Please enter integer number between {0} and {1}: ", start, end);
            string input = Console.ReadLine();
            int number;
            try
            {
                number = int.Parse(input);
                if (number <= start || number > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException)
            {
                throw;
            }

            return number;
        }
    }
}