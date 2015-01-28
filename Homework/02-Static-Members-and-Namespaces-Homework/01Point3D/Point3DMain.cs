namespace Points3D
{
    using System;

    internal class Point3DMain
    {
        internal static void Main()
        {
            Point3D pointZero = Point3D.StartingPoint3D;

            Point3D pointOne = new Point3D(1.0, 1.0, 1.0);
            Point3D pointTwo = new Point3D(2.0, 2.0, 2.0);

            Point3D[] points = new Point3D[] { pointZero, pointOne, pointTwo };

            foreach (Point3D point in points)
            {
                Console.WriteLine(point);
            }
        }
    }
}