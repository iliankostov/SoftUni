namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    public class Mage : Unit
    {
        private const int DefaultAttackPoints = 80;
        private const int DefaultHealthPoints = 80;
        private const int DefaultDefensePoints = 40;
        private const int DefaultEnergyPoints = 120;
        private const int DefaultRangePoints = 2;

        public Mage(int x, int y, string name)
            : base(x, y, name, DefaultRangePoints, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
