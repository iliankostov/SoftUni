namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    internal abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;

        protected Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        protected Item(string id, string title, decimal price, string genre)
            : this(id, title, price)
        {
            this.Genre = genre;
        }

        protected Item(string id, string title, decimal price, IList<string> genres)
        {
            this.Genres = genres;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 4)
                {
                    throw new ArgumentException(
                        "Invalid item id!\r\n" +
                        "The item id cannot be an empty string or null.\r\n" +
                        "The item id should be at least four symbols long.");
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

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Invalid item title!\r\n" +
                        "The item title cannot be an empty string or null.");
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

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Invalid item price!\r\n" +
                        "The item price cannot be equal to zero.\r\n" +
                        "The item price should be a positive float point number.");
                }

                this.price = value;
            }
        }

        public string Genre { get; private set; }

        public IList<string> Genres { get; private set; }

        public override string ToString()
        {
            StringBuilder itemInfo = new StringBuilder();
            itemInfo.AppendLine(string.Format("{0} {1}", this.GetType().Name, this.Id));
            itemInfo.AppendLine(string.Format("Title: {0}", this.Title));
            itemInfo.AppendLine(string.Format("Price: {0:F2}", this.Price));
            if (this.Genre != null)
            {
                itemInfo.AppendLine(string.Format("Genre: {0}", this.Genre));
            }

            return itemInfo.ToString();
        }
    }
}