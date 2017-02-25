namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    public abstract class TankFactory
    {
        public abstract Tank CreateTank();
    }
}
