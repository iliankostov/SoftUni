namespace BattleShips.ConsoleClient.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Models;
    using BattleShips.ConsoleClient.Utilities;

    internal class RegisterCommand : Command
    {
        private const string RegisterEndpoint = Constants.Url + "api/account/register";

        public RegisterCommand(IEngine engine)
            : base(engine)
        {
        }

        public override async void Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new ArgumentException(Messages.CommandIsNotSupportedByEngine);
            }

            string email = commandArgs[1];
            string password = commandArgs[2];
            string confirmPassword = commandArgs[3];

            var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", email), 
                    new KeyValuePair<string, string>("Password", password), 
                    new KeyValuePair<string, string>("ConfirmPassword", confirmPassword)
                });

            var response = await this.Engine.Client.PostAsync(RegisterEndpoint, bodyData);
            Console.WriteLine(response.StatusCode);
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<ErrorDTO>();

                foreach (var errors in data.ModelState.Values)
                {
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
            }
        }
    }
}