using System;

class CatalanNumbers
{
    static void Main()
    {
    StartN:
        Console.Write("Please enter n in range [0..99]: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0 || n > 99)
        {
            goto StartN;
        }

        double factorial2NtoN2 = 1;
        for (int i = (2 * n); i > (n + 1); i--)
        {
            factorial2NtoN2 *= i;
        }

        double factorialN = 1;
        for (int j = 2; j <= n; j++)
        {
            factorialN *= j;
        }

        double numberCatalan = factorial2NtoN2 / factorialN;
        Console.WriteLine("Nth Catalan number = {0}", numberCatalan);

    }
}