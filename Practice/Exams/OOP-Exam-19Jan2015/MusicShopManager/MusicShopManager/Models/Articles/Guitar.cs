namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;

    internal abstract class Guitar: Instrument, IGuitar
    {
        protected Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfStrings)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get;
            private set;
        }

        public string FingerboardWood
        {
            get;
            private set;
        }

        public int NumberOfStrings
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Strings: {0}\nBody wood: {1}\nFingerboard wood: {2}\n", this.NumberOfStrings, this.BodyWood, this.FingerboardWood);
        }
    }
}