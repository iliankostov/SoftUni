namespace Points3D
{
    using System;
    class Point3DMain
    {
        static void Main()
        {
            Point3D pointZero = Point3D.StartingPoint3D;

            Point3D pointOne = new Point3D(1.0, 1.0, 1.0);
            Point3D pointTwo = new Point3D(2.0, 2.0, 2.0);

            Random r = new Random();
            double rand = r.NextDouble() * (100 - 0) + 0;
            Point3D pointRandom = new Point3D(rand, rand, rand);

            Point3D[] points = new Point3D[] { pointZero, pointOne, pointTwo, pointRandom };

            foreach (Point3D point in points)
            {
                Console.WriteLine(point);
            }
        }
    }
}