namespace SquareRoot
{
    using System;
    class SquareRootMain
    {
        static void Main()
        {
            Console.Write("Please enter positive integer number: ");
            string input = Console.ReadLine();
            try
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double sqrtNum = Math.Sqrt(number);
                Console.WriteLine("The square root of {0} is {1:0.00}",number, sqrtNum);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
                Console.WriteLine("The problem is that you enter non-integer number.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid number.");
                Console.WriteLine("The problem is that you enter negative number.");
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }
    }
}