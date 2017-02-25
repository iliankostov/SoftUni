namespace DistanceCalculatorSOAPClient
{
    using System;

    using global::DistanceCalculatorSOAPClient.DistanceService;

    internal class DistanceCalculatorSOAPClient
    {
        private static void Main()
        {
            var client = new ServiceDistanceCalculatorClient();
            var start = new VectorPoint { X = 5, Y = 5 };
            var end = new VectorPoint { X = 10, Y = 10 };
            var result = client.CalculateDistance(start, end);
            Console.WriteLine(result);
        }
    }
}