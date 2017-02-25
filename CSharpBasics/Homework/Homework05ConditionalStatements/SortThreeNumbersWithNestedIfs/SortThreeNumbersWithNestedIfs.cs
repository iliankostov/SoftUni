using System;

class SortThreeNumbersWithNestedIfs
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
            Console.Write(a + " ");
            if (b >= c)
            {
                Console.Write(b + " ");
                Console.WriteLine(c);
            }
            if (c > b)
            {
                Console.Write(c + " ");
                Console.WriteLine(b);
            }          
        }

        else if (b >= a && b >= c)
        {
            Console.Write(b + " ");
            if (a >= c)
            {
                Console.Write(a + " ");
                Console.WriteLine(c);
            }
            if (c > a)
            {
                Console.Write(c + " ");
                Console.WriteLine(a);
            }
        }

        else if (c >= a && c >= b)
        {
            Console.Write(c + " ");
            if (a >= b)
            {
                Console.Write(a + " ");
                Console.WriteLine(b);
            }
            if (b > a)
            {
                Console.Write(b + " ");
                Console.WriteLine(a);              
            }
        }

    }
}