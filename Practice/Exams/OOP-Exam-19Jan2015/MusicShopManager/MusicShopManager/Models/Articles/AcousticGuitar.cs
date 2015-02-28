namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;
    using MusicShopManager.Models;

    internal class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private const int Strings = 6;
        private const bool IsElectronicConst = false;

        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, IsElectronicConst, bodyWood, fingerboardWood, Strings)
        {
            this.CaseIncluded = caseIncluded;
            StringMaterial = stringMaterial;
        }

        public bool CaseIncluded
        {
            get;
            private set;
        }

        public StringMaterial StringMaterial
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Case included: {0}\nString material: {1}", BoolToString(this.CaseIncluded), this.StringMaterial);
        }
    }
}