namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;
    using MultimediaShop.Contracts;

    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;

        public Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;          
        }

        public Item(string id, string title, decimal price, List<string> genres) 
            : this(id, title, price)
        {
            this.Genres = genres;
        }

        public Item(string id, string title, decimal price, string genre)
            : this(id, title, price)
        {
            this.Genre = genre;
        }

        public List<string> Genres
        {
            get;
            private set;
        }

        public string Genre
        {
            get;
            private set;
        }

        public string Id
        {
            get
            { 
                return this.id;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Item Id cannot be empty.");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentOutOfRangeException("Item Id must be at least 4 symbols long.");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Item Title cannot be empty.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get 
            {
                return this.price;
            }

            set
            {
                if (value < 0M)
                {
                    throw new IndexOutOfRangeException("Item Price cannot be negative.");
                }

                this.price = value;
            }
        }
    }
}