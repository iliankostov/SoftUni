namespace Estates.Data.Models
{
    using Interfaces;

    internal class Appartment : BuildingEstate, IApartment
    {
        public Appartment()
        {
            this.Type = EstateType.Apartment;
        }      
    }
}