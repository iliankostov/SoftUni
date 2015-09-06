namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class Data
    {
        public Data()
        {
            this.ProductById = new Dictionary<int, Product>();
            this.ProductsByPriceRange = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.ProductsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.ProductsByTitleAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.ProductsByTitleAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.ProductsBySupplierAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.ProductsBySupplierAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
        }

        public Dictionary<int, Product> ProductById { get; set; }

        public OrderedDictionary<decimal, SortedSet<Product>> ProductsByPriceRange { get; set; }

        public Dictionary<string, SortedSet<Product>> ProductsByTitle { get; set; }

        public Dictionary<Tuple<string, decimal>, SortedSet<Product>> ProductsByTitleAndPrice { get; set; }

        public Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> ProductsByTitleAndPriceRange { get; set; }

        public Dictionary<Tuple<string, decimal>, SortedSet<Product>> ProductsBySupplierAndPrice { get; set; }

        public Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> ProductsBySupplierAndPriceRange { get; set; }
    }
}