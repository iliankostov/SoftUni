namespace MassEffect.GameObjects.Ships
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var projectiles = new ShieldReaver(this.Damage);
            this.projectilesFired++;
            return projectiles;
        }

        public override string ToString()
        {
            string output = string.Empty;
            if (this.Health > 0)
            {
                output = string.Format("\n-Projectiles fired: {0}", this.projectilesFired);
            }
            return base.ToString() + output;
        }
    }
}
