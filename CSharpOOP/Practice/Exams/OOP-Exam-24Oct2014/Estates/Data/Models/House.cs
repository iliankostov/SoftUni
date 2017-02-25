namespace Estates.Data.Models
{
    using Interfaces;

    internal class House : Estate, IHouse
    {
        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}