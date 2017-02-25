namespace MusicShop.Models.Articles
{
    using MusicShopManager.Interfaces;

    internal class Microphone : Article, IMicrophone
    {
        public Microphone(string make, string model, decimal price, bool hasCable)
            : base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public bool HasCable
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Cable: {0}", BoolToString(this.HasCable));
        }
    }
}