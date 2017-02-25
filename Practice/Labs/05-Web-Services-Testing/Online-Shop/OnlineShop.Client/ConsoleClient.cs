namespace OnlineShop.Client
{
    using System;
    using RestSharp;

    internal class ConsoleClient
    {
        private static void Main()
        {
            var client = new RestClient("http://localhost:1623/api/");
            var request = new RestRequest("ads", Method.GET);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}