namespace MassEffect.GameObjects.Ships
{
    using System.Collections.Generic;
    using System.Text;

    using MassEffect.GameObjects.Enhancements;
    using MassEffect.GameObjects.Locations;
    using MassEffect.Interfaces;

    public abstract class Starship : IStarship
    {
        private readonly List<Enhancement> enhancements = new List<Enhancement>();

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);
            this.ApplyEfects(enhancement);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
           
            //// TODO

            return output.ToString();
        }

        protected void ApplyEfects(Enhancement enhancement)
        {
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }
    }
}
