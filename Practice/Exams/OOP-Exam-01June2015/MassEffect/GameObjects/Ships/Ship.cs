namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    class Ship : IStarship
    {
        private IList<Enhancement> enhancements = new List<Enhancement>();
        private int projectilesFired;

        public Ship(StarshipType type, string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Type = type;
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public StarshipType Type { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public IProjectile ProduceAttack()
        {
            projectilesFired++;

            switch (this.Type)
            {
                case StarshipType.Frigate:
                    return new ShieldReaver(this.Damage);
                case StarshipType.Cruiser:
                    return new PenetrationShell(this.Damage);
                case StarshipType.Dreadnought:
                    return new Laser(this.Damage);
                default:
                    throw new NotSupportedException("Ship type not supported.");
            }
        }

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
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            if (this.Health > 0)
            {


                output
                    .AppendLine(string.Format("--{0} - {1}",this.Name, this.Type))
                    .AppendLine(string.Format("-Location: {0}", this.Location.Name))
                    .AppendLine(string.Format("-Health: {0}", this.Health))
                    .AppendLine(string.Format("-Shields: {0}", this.Shields))
                    .AppendLine(string.Format("-Damage: {0}", this.Damage))
                    .AppendLine(string.Format("-Fuel: {0}", this.Fuel))
                    .Append("-Enhancements: ");

                foreach (Enhancement enhancement in this.Enhancements)
                {
                    output.Append(enhancement.Name);
                }

                output.AppendLine()
                    .Append(string.Format("-Projectiles fired: {0}", projectilesFired));

                return output.ToString();
            }

            output
                .AppendLine(string.Format("--{0} - {1}", this.Name, this.Type))
                .Append("(Destroyed)");

            return output.ToString();
        }
    }
}
