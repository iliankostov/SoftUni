using System;

class MatrixOfNumbers
{
    static void Main()
    {
    StartN:
        Console.Write("Please enter n in range [1..20]: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > 20)
        {
            goto StartN;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = i; j < n + i; j++)
            {
                Console.Write("{0} ", j);
            }
            Console.WriteLine();
        }                  
    }
}