namespace DistanceCalculatorRESTClient
{
    using System;

    using RestSharp;

    internal class DistanceCalculatorRESTClient
    {
        private static void Main()
        {
            var client = new RestClient("http://localhost:2038/api/");
            var request = new RestRequest("points", Method.GET);
            request.AddParameter("startX", 5);
            request.AddParameter("startY", 5);
            request.AddParameter("endX", 10);
            request.AddParameter("endY", 10);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}