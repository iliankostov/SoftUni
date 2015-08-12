namespace DistanceCalculatorSOAPService
{
    using System;

    public class ServiceDistanceCalculator : IServiceDistanceCalculator
    {
        public double CalculateDistance(int startX, int startY, int endX, int endY)
        {
            return Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startY - endY, 2));
        }
    }
}