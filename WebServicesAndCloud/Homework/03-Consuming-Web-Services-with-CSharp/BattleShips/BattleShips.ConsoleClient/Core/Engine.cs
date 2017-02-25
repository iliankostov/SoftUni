namespace BattleShips.ConsoleClient.Core
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Utilities;

    internal class Engine : IEngine
    {
        private readonly ICommandDispatcher commandDispatcher;

        private bool isStarted;

        public Engine(ICommandDispatcher commandDispatcher, HttpClient client)
        {
            this.commandDispatcher = commandDispatcher;
            this.commandDispatcher.Engine = this;
            this.Client = client;
        }

        public HttpClient Client { get; private set; }

        public string AccessToken { get; set; }

        public void Run()
        {
            this.isStarted = true;
            this.commandDispatcher.SeedCommands();

            while (this.isStarted)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException(Messages.CannotProcessEmptyCommand);
                    }

                    string[] inputArguments = input.Split(' ');

                    this.Client.DefaultRequestHeaders.Clear();
                    this.Client.DefaultRequestHeaders.Add("Authorization", this.AccessToken ?? "bearer");

                    this.commandDispatcher.DispatchCommand(inputArguments);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (TaskCanceledException tcex)
                {
                    Console.WriteLine(tcex.Message);
                }
            }
        }

        public void Stop()
        {
            this.isStarted = false;
        }
    }
}