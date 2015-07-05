namespace WinterIsComing.Models.Spells
{
    public class FireBreath : Spell
    {
        private new const int EnergyCost = 30;

        public FireBreath(int damage)
            : base(damage, EnergyCost)
        {
        }
    }
}
