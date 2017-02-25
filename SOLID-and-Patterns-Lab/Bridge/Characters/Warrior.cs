namespace RPG.Characters
{
    using Weapons;

    public class Warrior : Character
    {
        public Warrior(Weapon weapon)
            :base(weapon)
        {
        }

        public Weapon Weapon
        {
            get;
            set;
        }
    }
}