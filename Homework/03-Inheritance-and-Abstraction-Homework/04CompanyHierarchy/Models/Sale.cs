namespace CompanyHierarchy
{
    using System;

    public class Sale : ISale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
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
                    throw new ArgumentException("Your price cannot be negative.");
                }

                this.price = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Your product name cannot be empty.");
                }

                this.productName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product name: {0}\nDate: {1}\nPrice: {2:0.00}", this.ProductName, this.Date.ToString("dd-MM-yyyy"), this.Price);
        }
    }
}
