namespace WinterIsComing.Models.Spells
{
    public class Blizzard : Spell
    {
        private new const int EnergyCost = 40;

        public Blizzard(int damage)
            : base(damage, EnergyCost)
        {
        }
    }
}
