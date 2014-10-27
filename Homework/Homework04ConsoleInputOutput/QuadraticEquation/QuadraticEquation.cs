using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Please enter number a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Please enter number b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Please enter number c = ");
        double c = double.Parse(Console.ReadLine());
        double x1, x2;

        double insideSquareRoot = (b * b) - 4 * a * c;

        if (insideSquareRoot < 0)
        {            
            Console.WriteLine("no real roots");
        }
        else
        {
            double sqrt = Math.Sqrt(insideSquareRoot);
            x1 = (-b - sqrt) / (2 * a);
            x2 = (-b + sqrt) / (2 * a);
            if (x1 != x2)
            {
                Console.WriteLine("x1 = {0}; x2 = {1}", x1, x2);
            }
            else
            {
                Console.WriteLine("x1 = x2 = {0}", x1);
            }
        }      
    }
}