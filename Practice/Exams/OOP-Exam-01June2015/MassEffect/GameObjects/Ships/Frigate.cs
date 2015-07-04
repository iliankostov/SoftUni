namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship
    {
        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            return new ShieldReaver(this.Damage);
        }
    }
}
