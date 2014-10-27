using System;

class Triangle
{
    static void Main()
    {
        double aX = double.Parse(Console.ReadLine());
        double aY = double.Parse(Console.ReadLine());
        double bX = double.Parse(Console.ReadLine());
        double bY = double.Parse(Console.ReadLine());
        double cX = double.Parse(Console.ReadLine());
        double cY = double.Parse(Console.ReadLine());

        double a = Math.Sqrt(Math.Pow((bX - aX), 2) + Math.Pow((bY - aY), 2));
        double b = Math.Sqrt(Math.Pow((cX - bX), 2) + Math.Pow((cY - bY), 2));
        double c = Math.Sqrt(Math.Pow((aX - cX), 2) + Math.Pow((aY - cY), 2));

        double p = (a + b + c) / 2;

        if ((a + b) > c && (b + c) > a && (a + c) > b)
        {
            Console.WriteLine("Yes");
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("{0:F2}", area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", a);
        }
    }
}