using System;

class Program
{
    static void Main()
    {
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("d = ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("e = ");
        double e = double.Parse(Console.ReadLine());

        if (a >= b && a >= c && a >= d && a >= e)
        {
            Console.WriteLine("biggest = " + a);
        }
        else if (b >= a && b >= c && b >= d && b >= e)
        {
            Console.WriteLine("biggest = " + b);
        }
        else if (c >= a && c >= b && c >=d && c >= e)
        {
            Console.WriteLine("biggest = " + c);
        }
        else if (d >= a && d >= b && d >= c && d >= e)
        {
            Console.WriteLine("biggest = " + d);
        }
        else if (e >= a && e >= b && e >= c && e >= d)
        {
            Console.WriteLine("biggest = " + e);
        }

    }
}