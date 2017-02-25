namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class PlayCommand : Command
    {
        private const string PlayGameEndpoint = Constants.Url + "api/games/play";

        public PlayCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new ArgumentException("Invalid command");
            }

            string gameId = commandArgs[1];
            string possitionX = commandArgs[2];
            string possitionY = commandArgs[3];

            var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId), 
                    new KeyValuePair<string, string>("PossitionX", possitionX), 
                    new KeyValuePair<string, string>("PossitionY", possitionY)
                });

            var request = await this.Engine.Client.PostAsync(PlayGameEndpoint, bodyData);
            Console.WriteLine(request.StatusCode);
            if (!request.IsSuccessStatusCode)
            {
                var error = await request.Content.ReadAsAsync<ErrorDTO>();
                Console.WriteLine(error.Message);
            }
        }
    }
}