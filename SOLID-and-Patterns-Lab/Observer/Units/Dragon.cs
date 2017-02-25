namespace Skyrim.Units
{
    using System.Collections.Generic;
    using Items;

    public delegate void OnDeathDeligate(Weapon weapon);

    public class Dragon : Unit
    {
        private readonly IList<Warrior> warriors = new List<Warrior>();
        private readonly Weapon dropWeapon = new Weapon(100, 100);
        private int healthPoints;

        public event OnDeathDeligate OnDeath;

        public Dragon(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
        }

        public override int HealthPoints
        {
            get
            {   
                return this.healthPoints;
            }
            set
            {
                this.healthPoints = value;

                if (value < 0)
                {
                    if (this.OnDeath != null)
                    {
                        this.OnDeath(this.dropWeapon);
                    }
                }
            }
        }

        public void Attach(Warrior warrior)
        {
            this.warriors.Add(warrior);
        }

        public void Detach(Warrior warrior)
        {
            this.warriors.Remove(warrior);
        }

        public void Notify()
        {
            foreach (var warrior in warriors)
            {
                warrior.Update(this.dropWeapon);
            }
        }
    }
}
