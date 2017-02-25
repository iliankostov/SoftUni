namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class GetGamesCommand : Command
    {
        private const string GetGamesEndpoint = Constants.Url + "api/games/available";

        public GetGamesCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            var request = this.Engine.Client.GetAsync(GetGamesEndpoint).Result;
            Console.WriteLine(request.StatusCode);
            if (!request.IsSuccessStatusCode)
            {
                var error = await request.Content.ReadAsAsync<ErrorDTO>();
                Console.WriteLine(error.Message);
            }
            else
            {
                var games = await request.Content.ReadAsAsync<IEnumerable<GetGamesDTO>>();
                foreach (var game in games)
                {
                    Console.WriteLine(game.Id);
                }
            }
        }
    }
}