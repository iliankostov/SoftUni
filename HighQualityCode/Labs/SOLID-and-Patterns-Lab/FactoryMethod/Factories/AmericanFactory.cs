namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    class AmericanFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("M1 Abrams", 5.4, 120);
        }
    }
}
