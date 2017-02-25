namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    public class Warrior : Unit
    {
        private const int DefaultAttackPoints = 120;
        private const int DefaultHealthPoints = 180;
        private const int DefaultDefensePoints = 70;
        private const int DefaultEnergyPoints = 60;
        private const int DefaultRangePoints = 1;

        public Warrior(int x, int y, string name)
            : base(x, y, name, DefaultRangePoints, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.CombatHandler = new WarriorCombatHandler(this);
        }
    }
}
