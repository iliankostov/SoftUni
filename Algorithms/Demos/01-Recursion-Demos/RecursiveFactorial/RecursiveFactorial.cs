namespace RecursiveFactorial
{
    using System;

    internal class RecursiveFactorial
    {
        private static decimal Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        private static void Main()
        {
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine());

            decimal factorial = Factorial(number);
            Console.WriteLine("{0}! = {1}", number, factorial);
        }
    }
}