namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class PenetrationShell : IProjectile
    {
        public PenetrationShell(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public void Hit(IStarship ship)
        {
            ship.Health -= this.Damage;
        }
    }
}
