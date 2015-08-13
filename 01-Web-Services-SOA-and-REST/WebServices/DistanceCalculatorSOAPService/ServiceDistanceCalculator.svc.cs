namespace DistanceCalculatorSOAPService
{
    using System;

    public class ServiceDistanceCalculator : IServiceDistanceCalculator
    {
        public double CalculateDistance(VectorPoint start, VectorPoint end)
        {
            return Math.Sqrt(Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2));
        }
    }
}