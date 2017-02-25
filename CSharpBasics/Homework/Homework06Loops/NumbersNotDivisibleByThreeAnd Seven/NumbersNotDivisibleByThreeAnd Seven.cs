using System;

class Program
{
    static void Main()
    {
        Console.Write("Plese enter positive number n = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                Console.Write("");
            }
            else
            {
                Console.Write("{0} ", i);
            }
        }
    }
}