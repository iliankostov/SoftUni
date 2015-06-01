namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class ShieldReaver : IProjectile
    {
        public ShieldReaver(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public void Hit(IStarship ship)
        {
            ship.Health -= this.Damage;
            ship.Shields -= this.Damage*2;
        }
    }
}
