namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    class GermanFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("Tiger", 4.5, 120);
        }
    }
}
