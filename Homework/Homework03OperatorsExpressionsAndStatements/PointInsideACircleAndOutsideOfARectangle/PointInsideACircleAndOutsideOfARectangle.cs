using System;

class PointInsideACircleAndOutsideOfARectangle
{
    static void Main()
    {
        Console.Write("Please input number x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Please input number y: ");
        double y = double.Parse(Console.ReadLine());
        double r = 1.5;
        double pointToCenter;
        if (y > 1)
        {
            pointToCenter = Math.Sqrt( (x-1)*(x-1) + (y-1)*(y-1));
            if (pointToCenter <= r)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}