namespace Catalog
{
    using System;
    using System.Text;
    class Component
    {
        // Create fields
        private string name;
        private string details; // I haven't got condition to display details.
        private decimal price;

        // Create first constructor
        public Component(string name, decimal price)
        {
            this.Price = price;
            this.Name = name;
        }

        // Create second constructor
        public Component(string name, decimal price, string details = null) : this(name, price)
        {
            this.Details = details;
        }

        // Create and validate property Name
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name can't be empty.");
                }
                this.name = value;
            }
        }

        // Create and validate property Price
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0M)
                {
                    throw new IndexOutOfRangeException("The price can not be negative.");
                }
                this.price = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
            }
        }

        // Create and validate property Details
        public string Details
        {
            get { return this.details; }
            set
            {
                if (value == "")
                {
                    throw new ArgumentNullException("The details can't be empty.");
                }
                this.details = value;
            }
        }

        // Override ToString() method
        public override string ToString()
        {
            StringBuilder componentsStringBuild = new StringBuilder();
            if (this.Name != null)
            {
                componentsStringBuild.Append(this.Name + "; ");
            }
            // If you want to display Details uncomment the next 4 lines.
            //if (this.Details != null)
            //{
            //    componentsStringBuild.Append("Details: " + this.Details + "; ");
            //}
            componentsStringBuild.Append("Price: " + this.Price + " BGN");
            return componentsStringBuild.ToString();
        }

    }
}