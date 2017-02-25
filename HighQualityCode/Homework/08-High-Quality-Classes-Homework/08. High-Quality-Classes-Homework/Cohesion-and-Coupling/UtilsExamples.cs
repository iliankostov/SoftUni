namespace CohesionAndCoupling
{
    using System;

    using MathUtils;
    using StringUtils;

    internal class UtilsExamples
    {
        internal static void Main()
        {
            Console.WriteLine(FileNameUtils.GetFileExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", DistanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", DistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            SpaceFigure.Width = 3;
            SpaceFigure.Height = 4;
            SpaceFigure.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", SpaceFigure.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", SpaceFigure.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", SpaceFigure.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", SpaceFigure.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", SpaceFigure.CalcDiagonalYZ());
        }
    }
}