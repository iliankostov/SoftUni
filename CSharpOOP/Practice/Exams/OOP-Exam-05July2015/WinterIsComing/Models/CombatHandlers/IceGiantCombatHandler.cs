namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var nextTargets = new List<IUnit>();

            var candidateTargetsList = candidateTargets as IList<IUnit> ?? candidateTargets.ToList();

            if (candidateTargetsList.Any())
            {
                if (this.Unit.HealthPoints > 150)
                {
                    nextTargets = candidateTargetsList.ToList();
                }
                else
                {
                    nextTargets.Add(candidateTargetsList.First());
                }
            }

            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            var spell = new Stomp(this.Unit.AttackPoints);

            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, "Stomp"));
            }

            this.Unit.AttackPoints += 5;
            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}
