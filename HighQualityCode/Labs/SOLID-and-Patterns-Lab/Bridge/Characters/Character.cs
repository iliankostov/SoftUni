namespace RPG.Characters
{
    using Weapons;

    public abstract class Character
    {
        protected Character(Weapon weapon)
        {
            this.Weapon = weapon;
        }

        public Weapon Weapon
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format("{0} wields weapon {1}", this.GetType().Name, this.Weapon.GetType().Name);
        }
    }
}
