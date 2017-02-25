namespace MassEffect.GameObjects.Projectiles
{
    using System;

    using MassEffect.Interfaces;

    public class Laser : Projectiles
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int damageLeft = this.Damage - ship.Shields;
            ship.Shields -= this.Damage;

            if (damageLeft > 0)
            {
                ship.Health -= damageLeft;
            }
        }
    }
}
