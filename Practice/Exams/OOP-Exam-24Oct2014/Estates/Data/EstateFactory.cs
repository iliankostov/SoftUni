namespace Estates.Data
{
    using System;

    using Engine;
    using Interfaces;
    using Models;
    using Offers;

    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Appartment();
                case EstateType.Office:
                    return new Office();
                case EstateType.House:
                    return new House();
                case EstateType.Garage:
                    return new Garage();
                default:
                    throw new Exception("Cannot create estate.");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Sale:
                    return new SaleOffer();
                case OfferType.Rent:
                    return new RentOffer();
                default:
                    throw new Exception("Cannot create offer.");
            }
        }
    }
}
