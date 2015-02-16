namespace Models
{
    internal class Payment
    {
        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} for {1:0.00}lv.", this.ProductName, this.Price);
        }
    }
}