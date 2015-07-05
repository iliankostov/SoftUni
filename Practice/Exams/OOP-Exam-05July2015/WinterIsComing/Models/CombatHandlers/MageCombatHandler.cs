namespace WinterIsComing.Models.CombatHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WinterIsComing.Contracts;
    using WinterIsComing.Core;
    using WinterIsComing.Core.Exceptions;
    using WinterIsComing.Models.Spells;

    public class MageCombatHandler : CombatHandler
    {
        public MageCombatHandler(IUnit unit)
            : base(unit)
        {
            this.SpellFinder = true;
        }

        public bool SpellFinder { get; set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var nextTargets = new List<IUnit>();

            var candidateTargetsList = candidateTargets as IList<IUnit> ?? candidateTargets.ToList();

            if (candidateTargetsList.Any())
            {
                var threeTargetsWithMaxHealth =
                    candidateTargetsList
                    .OrderByDescending(t => t.HealthPoints)
                    .Take(3)
                    .ToList();

                var maxHealt = threeTargetsWithMaxHealth.First();
                var equal = threeTargetsWithMaxHealth.Where(t => t.HealthPoints == maxHealt.HealthPoints);

                if (equal.Count() > 1)
                {
                    nextTargets = threeTargetsWithMaxHealth.OrderBy(t => t.Name).ToList();                    
                }
                else
                {
                    nextTargets = threeTargetsWithMaxHealth;
                }
            }

            return nextTargets;
        }

        public override ISpell GenerateAttack()
        {
            ISpell spell;
            int damage = this.Unit.AttackPoints;
            string nextSpellString = this.SpellFinder ? "FireBreath" : "Blizzard";

            var fireBreath = new FireBreath(damage);
            var blizzard = new Blizzard(damage * 2);

            if (this.Unit.EnergyPoints > fireBreath.EnergyCost)
            {
                if (this.SpellFinder)
                {
                    this.SpellFinder = false;
                    spell = fireBreath;
                    this.Unit.EnergyPoints -= spell.EnergyCost;
                }
                else
                {
                    this.SpellFinder = true;
                    spell = blizzard;
                    this.Unit.EnergyPoints -= spell.EnergyCost;
                }
            }
            else
            {
                throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, nextSpellString));
            }

            return spell;
        }
    }
}
