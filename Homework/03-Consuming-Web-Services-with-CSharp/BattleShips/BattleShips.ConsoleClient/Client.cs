namespace BattleShips.ConsoleClient
{
    using System;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Core;

    internal class Client
    {
        private static void Main()
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 5);

            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher, client);
            engine.Run();
        }
    }
}