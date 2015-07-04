namespace MassEffect.Engine.Commands
{
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        public IStarship ParseStarship(string name)
        {
            var starship = this.GameEngine.Starships.FirstOrDefault(s => s.Name == name);
            if (starship == null)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            return starship;
        }
    }
}
