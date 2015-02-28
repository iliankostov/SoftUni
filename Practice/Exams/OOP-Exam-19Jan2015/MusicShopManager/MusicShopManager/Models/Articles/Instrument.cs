namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;

    internal abstract class Instrument : Article, IInstrument
    {
        protected Instrument(string make, string model, decimal price, string color, bool isElectronic)
            :base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }
        public string Color
        {
            get;
            private set;
        }

        public bool IsElectronic
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Color: {0}\nElectronic: {1}\n", this.Color, BoolToString(this.IsElectronic));
        }
    }
}