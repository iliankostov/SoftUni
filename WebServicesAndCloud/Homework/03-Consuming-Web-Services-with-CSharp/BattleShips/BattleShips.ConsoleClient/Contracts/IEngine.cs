namespace BattleShips.ConsoleClient.Contracts
{
    using System.Net.Http;

    public interface IEngine
    {
        HttpClient Client { get; }

        string AccessToken { get; set; }

        void Run();

        void Stop();
    }
}