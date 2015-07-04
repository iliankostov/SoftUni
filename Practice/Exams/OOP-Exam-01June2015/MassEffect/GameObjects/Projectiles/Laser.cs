namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public class Laser : Projectiles
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ship.Shields -= this.Damage;
            int damageLeft = this.Damage - ship.Shields;

            if (damageLeft < 0)
            {
                ship.Health -= damageLeft;
            }
        }
    }
}
