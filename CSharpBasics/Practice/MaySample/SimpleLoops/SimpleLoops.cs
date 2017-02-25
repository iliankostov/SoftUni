using System;
using System.Numerics;

class SimpleLoops
{
    static void Main()
    {      
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        BigInteger tN = t3 + t2 + t1;
        if (n < 4)
        {
            if (n == 1)
            {
                tN = t1;
            }
            else if (n == 2)
            {
                tN = t2;
            }
            else
            {
                tN = t3;
            }
        }
        else
        {
            for (int i = 4; i < n; i++)
            {
                t1 = t2;
                t2 = t3;
                t3 = tN;
                tN = t3 + t2 + t1;
            }
        }
        Console.WriteLine(tN);
    }
}