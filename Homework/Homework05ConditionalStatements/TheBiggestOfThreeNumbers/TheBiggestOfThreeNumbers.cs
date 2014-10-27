using System;

class TheBiggestOfThreeNumbers
{
    static void Main()
    {
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        if (a >= b && a >= c)
        {
            Console.WriteLine("biggest = " + a);                    
        }

        else if (b >= a && b >= c)
        {
            Console.WriteLine("biggest = " + b);                     
        }

        else if (c >= a && c >= b)
        {
            Console.WriteLine("biggest = " + c);          
        }
    }
}