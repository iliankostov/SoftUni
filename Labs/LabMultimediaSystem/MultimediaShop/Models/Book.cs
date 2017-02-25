namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, string genre)
            : base(id, title, price, genre)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The Author must be at least 3 symbols.");
                }

                this.author = value;
            }
        }
    }
}