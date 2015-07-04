namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage);
        }
    }
}
