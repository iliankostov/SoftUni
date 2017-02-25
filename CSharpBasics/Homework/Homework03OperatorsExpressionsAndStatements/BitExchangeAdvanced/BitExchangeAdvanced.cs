using System;

class BitExchangeAdvanced
{
    static void Main()
    {
        Console.Write("n = ");
        long n = long.Parse(Console.ReadLine());
        Console.Write("p = ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("q = ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        if (p + k > 32 || q + k > 32)
        {
            Console.WriteLine("out of range");
        }
        else if (k > 8 && p + k > q)
        {
            Console.WriteLine("overlaping");
        }
        else
        {
            if (p > q)
            {
                int temp = q;
                q = p;
                p = temp;
            }
            
            string maskSize = new string('1', k);
            long mask = Convert.ToInt32(maskSize, 2);
            
            long maskOne = mask << p;
            long maskTwo = mask << q;

            maskOne &= n;
            n &= ~maskOne;
            maskOne <<= (q - p);

            maskTwo &= n;
            n &= ~maskTwo;
            maskTwo >>= (q - p);

            n += maskOne;
            n += maskTwo;

            Console.WriteLine(n);
            
        }
    }
}