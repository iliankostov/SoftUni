namespace Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Book : Item
    {
        private string author;

        internal Book(string id, string title, decimal price, string author, string genre)
            : base(id, title, price, genre)
        {
            this.Author = author;
        }

        internal Book(string id, string title, decimal price, string author, IList<string> genres)
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

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 3)
                {
                    throw new ArgumentException(
                        "Invalid book author's name!\r\n" +
                        "The book author's name cannot be an empty string or null.\r\n" +
                        "The book author's name should be at least three symbols long.");
                }

                this.author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder bookInfo = new StringBuilder(base.ToString());
            bookInfo.Append(string.Format("Author: {0}", this.Author));
            return bookInfo.ToString();
        }
    }
}