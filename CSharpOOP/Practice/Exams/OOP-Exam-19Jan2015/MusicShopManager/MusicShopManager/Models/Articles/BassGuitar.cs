namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;

    internal class BassGuitar : Guitar, IBassGuitar
    {
        private const int Strings = 4;
        private const bool IsElectronicConst = true;

        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood)
            : base(make, model, price, color, IsElectronicConst, bodyWood, fingerboardWood, Strings)
        {
        }
    }
}