namespace DistanceCalculatorSOAPClient
{
    using System;

    using ServiceReferenceCalculator;

    internal class DistanceCalculatorSOAPClient
    {
        private static void Main()
        {
            var client = new ServiceDistanceCalculatorClient();
            var result = client.CalculateDistance(0, 5, 10, 5);
            Console.WriteLine(result);
        }
    }
}