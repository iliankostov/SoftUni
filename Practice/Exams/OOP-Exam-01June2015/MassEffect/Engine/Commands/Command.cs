namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Factories;
    using GameObjects.Enhancements;
    using GameObjects.Locations;
    using GameObjects.Ships;
    using MassEffect.Interfaces;

    public class Command
    {
        public Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public void Execute(string[] commandArgs)
        {
            switch (commandArgs[0].ToLower())
            {
                case "create":
                    StarshipType starshipType;
                    try
                    {
                        starshipType = (StarshipType) Enum.Parse(typeof(StarshipType), commandArgs[1]); 
                    }
                    catch (Exception)
                    {
                        throw new NotSupportedException("Starship type not supported.");
                    }

                    string name = commandArgs[2];

                    StarSystem location = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[3]);

                    var newShip = this.GameEngine.ShipFactory.CreateShip(starshipType, name, location);

                    if (commandArgs.Length > 4)
                    {
                        EnhancementType enhancementType;
                        try
                        {
                            enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[4]);
                        }
                        catch (Exception)
                        {
                            throw new NotSupportedException("Enhancement type not supported.");
                        }
                        var enchancement = this.GameEngine.EnhancementFactory.Create(enhancementType);

                        newShip.AddEnhancement(enchancement);
                    }

                    this.GameEngine.Starships.Add(newShip);

                    Console.WriteLine(Messages.CreatedShip, starshipType, name);
                    break;

                case "attack":
                    Ship attackerShip = this.GameEngine.Starships.FirstOrDefault(n => n.Name == commandArgs[1]) as Ship;
                    Ship targetShip = this.GameEngine.Starships.FirstOrDefault(n => n.Name == commandArgs[2]) as Ship;
                    if (attackerShip != null && targetShip != null)
                    {
                        IProjectile projectile = attackerShip.ProduceAttack();
                        targetShip.RespondToAttack(projectile);

                        Console.WriteLine(Messages.ShipAttacked, attackerShip.Name, targetShip.Name);

                        if (targetShip.Health < 0)
                        {
                            targetShip.Health = 0;
                            Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
                        }
                    }

                    break;

                case "status-report":
                    Ship shipForReport = this.GameEngine.Starships.FirstOrDefault(n => n.Name == commandArgs[1]) as Ship;
                    if (shipForReport != null)
                    {
                        Console.WriteLine(shipForReport.ToString());
                    }
                    
                    break;

                case "plot-jump":
                    
                    Ship shipForJump = this.GameEngine.Starships.FirstOrDefault(n => n.Name == commandArgs[1]) as Ship;
                    if (shipForJump != null)
                    {
                        StarSystem oldStarSystem = shipForJump.Location;
                        StarSystem newStarSystem = this.GameEngine.Galaxy.GetStarSystemByName(commandArgs[2]);
                        if (newStarSystem != null)
                        {
                            shipForJump.Location = newStarSystem;

                            Console.WriteLine(Messages.ShipTraveled, shipForJump.Name, oldStarSystem.Name, newStarSystem.Name);
                        }
                    }
                    break;
                case "over":
                    this.GameEngine.IsRunning = false;
                    break;
                default:
                    break;
            }
        }
    }
}
