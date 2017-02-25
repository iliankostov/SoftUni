namespace DistancesCalculator
{
    using System;
    using Points3D;

    public static class DistanceCalculator
    {
        // Create static method to calculate distance in the 3D space.
        public static double CalcDist(Point3D pointOne, Point3D pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            double z = pointOne.Z - pointTwo.Z;

            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }
    }
}
