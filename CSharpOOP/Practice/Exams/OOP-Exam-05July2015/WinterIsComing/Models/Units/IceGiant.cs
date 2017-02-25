namespace WinterIsComing.Models.Units
{
    using WinterIsComing.Models.CombatHandlers;

    public class IceGiant : Unit
    {
        private const int DefaultAttackPoints = 150;
        private const int DefaultHealthPoints = 300;
        private const int DefaultDefensePoints = 60;
        private const int DefaultEnergyPoints = 50;
        private const int DefaultRangePoints = 1;

        public IceGiant(int x, int y, string name)
            : base(x, y, name, DefaultRangePoints, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
