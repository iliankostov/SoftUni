namespace Estates.Data.Offers
{
    using Interfaces;

    internal class RentOffer : Offer, IRentOffer
    {
        public RentOffer()
        {
            this.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", this.PricePerMonth);
        }
    }
}