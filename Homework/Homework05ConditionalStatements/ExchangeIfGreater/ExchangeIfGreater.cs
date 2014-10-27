using System;

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Please enter number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter number b: ");
        double b = double.Parse(Console.ReadLine());

        if ( a > b )
        {
            double temp = b;
            b = a;
            a = temp;
        }

        Console.WriteLine(a + " " + b);
    }
}