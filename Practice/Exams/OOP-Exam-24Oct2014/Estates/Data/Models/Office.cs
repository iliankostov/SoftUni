namespace Estates.Data.Models
{
    using Interfaces;

    internal class Office : BuildingEstate, IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}