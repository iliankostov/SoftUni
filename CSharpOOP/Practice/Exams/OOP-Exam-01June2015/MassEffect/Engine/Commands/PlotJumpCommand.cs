namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string starshipNameString = commandArgs[1];
            string newLocationName = commandArgs[2];

            var starship = ParseStarship(starshipNameString);
            var oldLocation = starship.Location;
            var newLocation = this.GameEngine.Galaxy.GetStarSystemByName(newLocationName);

            if (oldLocation.Name == newLocation.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, oldLocation.Name));
            }

            this.GameEngine.Galaxy.TravelTo(starship, newLocation);
            Console.WriteLine(Messages.ShipTraveled, starship.Name, oldLocation.Name, newLocation.Name);
        }
    }
}
