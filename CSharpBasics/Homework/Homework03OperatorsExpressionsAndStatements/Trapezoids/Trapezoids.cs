using System;

class Trapezoids
{
    static void Main()
    {
        Console.Write("Plese enter base a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Plese enter base b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Plese enter height h: ");
        double h = double.Parse(Console.ReadLine());
        double areaRectangle = h * a;
        double areaTriangles = h * (b - a) / 2;
        double result = areaRectangle + areaTriangles;
        Console.WriteLine(result);
    }
}