using System;
class CalculateNFactorialDividedKFactorial
{
    static void Main()
    {
    StartN:
        Console.Write("Please enter n in range [2..99]: ");
        int n = int.Parse(Console.ReadLine());
        if ( n < 2 || n > 99 )
        {
            goto StartN;
        }
    StartK:
        Console.Write("Please enter k in range [1..n]: ");
        int k = int.Parse(Console.ReadLine());
        if ( k < 1 || k >= n )
        {
            goto StartK;
        }

        double divider = 1;

        for (int i = n; i > k; i--)
        {
            divider *= i;
        }
        Console.WriteLine("n! / k! = {0}", divider);
    }
}