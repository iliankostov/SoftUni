namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string starshipString = commandArgs[1];
            var starship = ParseStarship(starshipString);
            Console.WriteLine(starship);
        }
    }
}
