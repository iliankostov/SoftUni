namespace MusicShop.Models.Articles
{
    using System;
    using MusicShopManager.Interfaces;

    internal abstract class Article : IArticle
    {
        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get;
            private set;
        }

        public string Model
        {
            get;
            private set;
        }

        public decimal Price
        {
            get;
            private set;
        }

        public string BoolToString(bool boolValue)
        {
            return boolValue ? "yes" : "no";
        }

        public override string ToString()
        {
            return string.Format("= {0} {1} =\nPrice: ${2:F2}\n", this.Make, this.Model, this.Price);
        }
    }
}