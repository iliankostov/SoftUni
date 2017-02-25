namespace DistanceCalculatorRESTClient
{
    using System;

    using RestSharp;

    internal class DistanceCalculatorRESTClient
    {
        private static void Main()
        {
            var client = new RestClient("http://localhost:2038/api/");
            var request = new RestRequest("points/distance", Method.GET);
            request.AddParameter("StartX", 5);
            request.AddParameter("StartY", 5);
            request.AddParameter("EndX", 10);
            request.AddParameter("EndY", 10);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}