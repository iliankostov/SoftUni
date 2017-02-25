namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class LoginCommand : Command
    {
        private const string LoginEndpoint = Constants.Url + "Token";

        public LoginCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new ArgumentException("Invalid command");
            }

            string username = commandArgs[1];
            string password = commandArgs[2];

            var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", username), 
                    new KeyValuePair<string, string>("Password", password), 
                    new KeyValuePair<string, string>("Grant_Type", "password")
                });

            var response = await this.Engine.Client.PostAsync(LoginEndpoint, bodyData);
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsAsync<ErrorDTO>();
                Console.WriteLine(error.Error_Description);
            }
            else
            {
                var accessToken = await response.Content.ReadAsAsync<LoginDTO>();
                this.Engine.AccessToken = accessToken.Token_Type + " " + accessToken.Access_Token;
            }
        }
    }
}