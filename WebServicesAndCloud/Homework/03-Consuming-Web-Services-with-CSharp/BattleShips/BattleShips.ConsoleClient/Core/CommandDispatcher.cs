namespace BattleShips.ConsoleClient.Core
{
    using System;
    using System.Collections.Generic;
    using BattleShips.ConsoleClient.Contracts;
    using BattleShips.ConsoleClient.Core.Commands;
    using BattleShips.ConsoleClient.Utilities;

    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IDictionary<string, ICommand> commandsByName;

        public CommandDispatcher()
        {
            this.commandsByName = new Dictionary<string, ICommand>();
        }

        public IEngine Engine { get; set; }

        public void DispatchCommand(string[] commandArguments)
        {
            string commandName = commandArguments[0];
            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new ArgumentException(Messages.CommandIsNotSupportedByEngine);
            }

            ICommand command = this.commandsByName[commandName];
            command.Execute(commandArguments);
        }

        public void SeedCommands()
        {
            this.commandsByName["register"] = new RegisterCommand(this.Engine);
            this.commandsByName["login"] = new LoginCommand(this.Engine);
            this.commandsByName["get-games"] = new GetGamesCommand(this.Engine);
            this.commandsByName["create-game"] = new CreateGameCommand(this.Engine);
            this.commandsByName["join-game"] = new JoinGameCommand(this.Engine);
            this.commandsByName["play"] = new PlayCommand(this.Engine);
            this.commandsByName["exit"] = new ExitCommand(this.Engine);
        }
    }
}