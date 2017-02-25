namespace Catalog
{
    using System;
    using System.Text;
    class Computer
    {
        // Create fields
        private string name;
        private Component[] components;

        // Create constructor
        public Computer(string name, Component[] components)
        {
            this.Name = name;
            this.Components = components;
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

        // Create array property Components
        public Component[] Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        // Create and calculate property TotalPrice
        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0M;
                foreach (Component component in Components)
                {
                    sum += component.Price;
                }
                return sum;
            }
        }

        // Override ToString() method
        public override string ToString()
        {
            StringBuilder computerStringBuild = new StringBuilder();
            computerStringBuild.AppendLine("Name: " + this.Name);
            computerStringBuild.AppendLine("Components:");
            foreach (Component component in Components)
            {
                computerStringBuild.AppendLine(component.ToString());
            }
            computerStringBuild.AppendLine("Total Price: " + this.TotalPrice + " BGN");
            return computerStringBuild.ToString();
        }
    }

}