namespace MassEffect.Engine.Factories
{
    using System;

    using GameObjects.Locations;
    using GameObjects.Ships;
    using Interfaces;

    public class ShipFactory
    {
        public IStarship CreateShip(StarshipType type, string name, StarSystem location)
        {
            switch (type)
            {
                case StarshipType.Frigate:
                    return new Ship(StarshipType.Frigate, name, 60, 50, 30, 120, location);
                case StarshipType.Cruiser:
                    return new Ship(StarshipType.Cruiser, name, 100, 100, 50, 300, location);
                case StarshipType.Dreadnought:
                    return new Ship(StarshipType.Dreadnought, name, 200, 300, 150, 700, location);
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }
        }
    }
}
