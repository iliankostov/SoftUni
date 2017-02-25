namespace MusicShop.Models.Articles
{
    using System;
    using MusicShopManager.Interfaces;

    internal class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const int Strings = 6;
        private const bool IsElectronicConst = true;

        public ElectricGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets)
            : base(make, model, price, color, IsElectronicConst, bodyWood, fingerboardWood, Strings)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get;
            private set;
        }

        public int NumberOfFrets
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Adapters: {0}\nFrets: {1}", this.NumberOfAdapters, this.NumberOfFrets);
        }
    }
}