namespace FactoryMethod.Factories
{
    using TankManufacturer.Units;

    class RussianFactory : TankFactory
    {
        public override Tank CreateTank()
        {
            return new Tank("T 34", 3.3, 75);
        }
    }
}
