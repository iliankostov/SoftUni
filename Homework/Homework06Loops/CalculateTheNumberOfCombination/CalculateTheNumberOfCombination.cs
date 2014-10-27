using System;

class CalculateTheNumberOfCombination
{
    static void Main()
    {
    StartN:
        Console.Write("Please enter n in range [2..99]: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 2 || n > 99)
        {
            goto StartN;
        }
    StartK:
        Console.Write("Please enter k in range [1..n]: ");
        int k = int.Parse(Console.ReadLine());
        if (k < 1 || k >= n)
        {
            goto StartK;
        }

        double factorialNtoK = 1;
        for (int i = n; i > k; i--)
        {
            factorialNtoK *= i;
        }

        double divider = 1;
        for (int j = 2; j <= (n - k); j++)
        {
            divider *= j;
        }

        double result = factorialNtoK / divider;
        Console.WriteLine("n! / (k! * (n-k)!) = {0}", result);
                       
    }
}