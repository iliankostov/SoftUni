namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : IProjectile
    {
        public Laser(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public void Hit(IStarship ship)
        {
            int damage = this.Damage;
            if (damage > ship.Shields)
            {
                damage -= ship.Shields;
                ship.Shields = 0;
                ship.Health -= damage;
            }
            else
            {
                ship.Shields -= damage;
            }
        }
    }
}
