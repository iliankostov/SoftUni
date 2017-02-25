namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string typeString = commandArgs[1];
            string name = commandArgs[2];
            string locationString = commandArgs[3];

            var checkForShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == name);
            if (checkForShip != null)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            StarshipType starshipType;

            try
            {
                starshipType = (StarshipType)Enum.Parse(typeof(StarshipType), typeString);
            }
            catch (Exception)
            {
                throw new ShipException("Cannot find the starship type.");
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationString);

            var starship = this.GameEngine.ShipFactory.CreateShip(starshipType, name, location);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                string enhancementString = commandArgs[i];
                EnhancementType enhancementType;
                try
                {
                    enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), enhancementString);
                }
                catch (Exception)
                {
                    throw new ShipException("The type of enhancement do not exists.");
                }
                
                var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                starship.AddEnhancement(enhancement);
            }

            this.GameEngine.Starships.Add(starship);
            Console.WriteLine(Messages.CreatedShip, typeString, name);
        }
    }
}
