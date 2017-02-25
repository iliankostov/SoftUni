using System;

class PointInACircle
{
    static void Main()
    {
        Console.Write("Please input number x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Please input number y: ");
        double y = double.Parse(Console.ReadLine());
        byte r = 2;
        double pathToCenter = Math.Sqrt(x * x + y * y);
        if (pathToCenter == 0)
        {               
            Console.WriteLine(true);
        }
        else if (pathToCenter > 0)
        {
            bool result = pathToCenter <= r;
            Console.WriteLine(result);
        }
        else if (pathToCenter < 0)
        {
            bool result = pathToCenter >= r;
            Console.WriteLine(result);
        }        
    }
}