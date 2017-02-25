namespace DistancesCalculator
{
    using System;
    using Points3D;

    internal class DistanceCalculatorMain
    {
        internal static void Main()
        {
            Point3D pointZero = Point3D.StartingPoint3D;
            Point3D pointOne = new Point3D(1, 1, 1);
            Point3D pointTwo = new Point3D(2, 2, 2);

            Console.WriteLine("The distance between point 0 and 1 is {0:0.00}", DistanceCalculator.CalcDist(pointZero, pointOne));
            Console.WriteLine("The distance between point 0 and 2 is {0:0.00}", DistanceCalculator.CalcDist(pointZero, pointTwo));
        }
    }
}