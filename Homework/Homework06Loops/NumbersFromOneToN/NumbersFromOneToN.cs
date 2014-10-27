using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Plese enter positive number n = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ", i);
        }
    }
}