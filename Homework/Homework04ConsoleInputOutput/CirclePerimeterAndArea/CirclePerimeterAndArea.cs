using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Please enter circle's radius r = ");
        double r = double.Parse(Console.ReadLine());
        double pi = 3.14159265359;
        double perimeter = (2 * pi * r);
        double area = (r * r * pi);
        Console.WriteLine("r = {0, 13:F2} \nperimeter = {1, 1:F2} \narea = {2, 10:F2}",r ,perimeter ,area );
    }
}