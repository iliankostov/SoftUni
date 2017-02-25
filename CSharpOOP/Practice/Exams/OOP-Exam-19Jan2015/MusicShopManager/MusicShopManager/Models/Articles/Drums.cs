namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;

    internal class Drums : Instrument, IDrums
    {
        private const bool IsElectronicConst = false;

        public Drums(string make, string model, decimal price, string color, int width, int height)
            : base(make, model, price, color, IsElectronicConst)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Size: {0}cm x {1}cm", this.Width, this.Height);
        }
    }
}