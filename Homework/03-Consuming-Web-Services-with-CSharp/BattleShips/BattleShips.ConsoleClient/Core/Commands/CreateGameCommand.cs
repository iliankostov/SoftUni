namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class CreateGameCommand : Command
    {
        private const string CreateGameEndpoint = Constants.Url + "api/games/create";

        public CreateGameCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            var response = await this.Engine.Client.PostAsync(CreateGameEndpoint, null);
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<ErrorDTO>();
                Console.WriteLine(error.Message);
            }
            else
            {
                var gameId = await response.Content.ReadAsStringAsync();
                Console.WriteLine(gameId);
            }
        }
    }
}