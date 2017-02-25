﻿namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class PenetrationShell : Projectiles
    {
        public PenetrationShell(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ship.Health -= this.Damage;
        }
    }
}
