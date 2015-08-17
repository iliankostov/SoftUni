namespace TestBinaryHeap
{
    using System;

    internal class TestProduct : IComparable
    {
        public TestProduct(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            var product = (TestProduct)obj;

            if (this.Price.CompareTo(product.Price) > 0)
            {
                return 1;
            }

            if (this.Price.CompareTo(product.Price) < 0)
            {
                return -1;
            }

            return 0;
        }
    }
}