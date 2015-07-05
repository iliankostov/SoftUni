namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class WarriorCombatHandler : CombatHandler
    {
        private const int BorderBonusHealth = 50;

        private const int BonusEnergy = 15;

        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var nextTargets = new List<IUnit>();

            var candidateTargetsList = candidateTargets as IList<IUnit> ?? candidateTargets.ToList();

            if (candidateTargetsList.Any())
            {
                nextTargets.Add(candidateTargetsList.OrderBy(t => t.HealthPoints).ThenBy(t => t.Name).FirstOrDefault());

                if (this.Unit.HealthPoints < BorderBonusHealth)
                {
                    this.Unit.EnergyPoints += BonusEnergy;
                }
            }

            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            var damage = this.Unit.AttackPoints;
            var health = this.Unit.HealthPoints;
            if (health <= 80)
            {
                damage += health * 2;
            }

            var spell = new Cleave(damage);

            if (this.Unit.EnergyPoints < spell.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, "Cleave"));
            }

            this.Unit.EnergyPoints -= spell.EnergyCost;
            return spell;
        }
    }
}
