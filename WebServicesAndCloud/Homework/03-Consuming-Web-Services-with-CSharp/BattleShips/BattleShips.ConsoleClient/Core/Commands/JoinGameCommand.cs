namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class JoinGameCommand : Command
    {
        private const string JoinGameEndpoint = Constants.Url + "api/games/join";

        public JoinGameCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 2)
            {
                throw new ArgumentException(Messages.CommandIsNotSupportedByEngine);
            }

            string gameId = commandArgs[1];
            var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId)
                });
            var request = await this.Engine.Client.PostAsync(JoinGameEndpoint, bodyData);
            Console.WriteLine(request.StatusCode);
            if (!request.IsSuccessStatusCode)
            {
                var error = await request.Content.ReadAsAsync<ErrorDTO>();
                Console.WriteLine(error.Message);
            }
        }
    }
}