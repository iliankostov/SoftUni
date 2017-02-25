namespace CohesionAndCoupling
{
    using System;

    public static class SpaceFigure
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalculateDiagonalXYZ()
        {
            return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2) + Math.Pow(Depth, 2));
        }

        public static double CalcDiagonalXY()
        {
            return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
        }

        public static double CalcDiagonalXZ()
        {
            return Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Depth, 2));
        }

        public static double CalcDiagonalYZ()
        {
            return Math.Sqrt(Math.Pow(Height, 2) + Math.Pow(Depth, 2));
        }

        public static double CalculateVolume()
        {
            return Width * Height * Depth;
        }
    }
}
