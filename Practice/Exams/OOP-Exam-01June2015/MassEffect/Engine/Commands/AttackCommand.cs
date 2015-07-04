namespace MassEffect.Engine.Commands
{
    using System;

    using MassEffect.Exceptions;
    using MassEffect.Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerString = commandArgs[1];
            string deffenderString = commandArgs[2];

            var attacker = ParseStarship(attackerString);

            var deffender = ParseStarship(deffenderString);

            if (attacker.Location.Name != deffender.Location.Name)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            var projectiles = attacker.ProduceAttack();
            deffender.RespondToAttack(projectiles);
            if (deffender.Shields < 0) 
            {
                deffender.Shields = 0;               
            }

            Console.WriteLine(Messages.ShipAttacked, attacker.Name, deffender.Name);
            if (deffender.Health <= 0)
            {
                deffender.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, deffender.Name);
            }
        }
    }
}
