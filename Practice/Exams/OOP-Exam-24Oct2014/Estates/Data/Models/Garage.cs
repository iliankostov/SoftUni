namespace Estates.Data.Models
{
    using Interfaces;

    internal class Garage : Estate, IGarage
    {
        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}