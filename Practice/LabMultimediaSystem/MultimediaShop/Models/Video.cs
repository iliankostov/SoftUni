namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    public class Video : Item
    {
        public Video(string id, string title, decimal price, int length, string genre) 
            : base(id, title, price, genre)
        {
            this.Length = length;
        }

        public Video(string id, string title, decimal price, int length, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public int Length
        {
            get;
            private set;
        }
    }
}