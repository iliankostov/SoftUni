namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;

    public class ProductCollection : IProductCollection
    {
        private readonly Data data;

        public ProductCollection()
        {
            this.data = new Data();
        }

        public int Count
        {
            get
            {
                return this.data.ProductById.Count;
            }
        }

        public void Add(int id, string title, string supplier, decimal price)
        {
            var product = new Product
                {
                    Id = id, 
                    Title = title, 
                    Supplier = supplier, 
                    Price = price
                };

            this.AddProductById(id, product);
            this.AddProductsByPriceRange(price, product);
            this.AddProductsByTitle(title, product);
            this.AddProductsByTitleAndPrice(title, price, product);
            this.AddProductByTitleAndPriceRange(title, price, product);
            this.AddProductsBySupplierAndPrice(supplier, price, product);
            this.AddProductBySupplierAndPriceRange(supplier, price, product);
        }

        public bool Remove(int id)
        {
            if (!this.data.ProductById.ContainsKey(id))
            {
                return false;
            }

            var product = this.data.ProductById[id];

            this.RemoveProductById(id);
            this.RemoveProductsByPriceRange(product);
            this.RemoveProductsByTitle(product);
            this.RemoveProductsByTitleAndPrice(product);
            this.RemoveProductByTitleAndPriceRange(product);
            this.RemoveProductsBySupplierAndPrice(product);
            this.RemoveProductBySupplierAndPriceRange(product);

            return true;
        }

        public IEnumerable<Product> FindByPriceRange(decimal startPrice, decimal endPrice)
        {
            var collections = this.data.ProductsByPriceRange.Range(startPrice, true, endPrice, true);
            if (collections == null)
            {
                yield break;
            }

            foreach (var collection in collections)
            {
                foreach (var product in collection.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindByTitle(string title)
        {
            if (!this.data.ProductsByTitle.ContainsKey(title))
            {
                yield break;
            }

            var products = this.data.ProductsByTitle[title];
            if (products == null)
            {
                yield break;
            }

            foreach (var product in products)
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindByTitleAndPrice(string title, decimal price)
        {
            var titleAndPrice = this.DoubleKey(title, price);
            if (!this.data.ProductsByTitleAndPrice.ContainsKey(titleAndPrice))
            {
                yield break;
            }

            var products = this.data.ProductsByTitleAndPrice[titleAndPrice];
            if (products == null)
            {
                yield break;
            }

            foreach (var product in products)
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice)
        {
            var collections = this.data.ProductsByTitleAndPriceRange[title].Range(startPrice, true, endPrice, true);
            if (collections == null)
            {
                yield break;
            }

            foreach (var collection in collections)
            {
                foreach (var product in collection.Value)
                {
                    yield return product;
                }
            }
        }

        public IEnumerable<Product> FindBySupplierAndPrice(string supplier, decimal price)
        {
            var supplierAndPrice = this.DoubleKey(supplier, price);
            if (!this.data.ProductsBySupplierAndPrice.ContainsKey(supplierAndPrice))
            {
                yield break;
            }

            var products = this.data.ProductsBySupplierAndPrice[supplierAndPrice];
            if (products == null)
            {
                yield break;
            }

            foreach (var product in products)
            {
                yield return product;
            }
        }

        public IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, decimal startPrice, decimal endPrice)
        {
            var collections = this.data.ProductsBySupplierAndPriceRange[supplier].Range(startPrice, true, endPrice, false);
            if (collections == null)
            {
                yield break;
            }

            foreach (var collection in collections)
            {
                foreach (var product in collection.Value)
                {
                    yield return product;
                }
            }
        }

        public Product Find(int id)
        {
            if (!this.data.ProductById.ContainsKey(id))
            {
                return null;
            }

            return this.data.ProductById[id];
        }

        private void AddProductById(int id, Product product)
        {
            this.data.ProductById.EnsureKeyExists(id);
            this.data.ProductById[id] = product;
        }

        private void AddProductsByPriceRange(decimal price, Product product)
        {
            this.data.ProductsByPriceRange.EnsureKeyExists(price);
            if (this.data.ProductsByPriceRange[price].Contains(product))
            {
                this.data.ProductsByPriceRange[price].Remove(product);
            }

            this.data.ProductsByPriceRange[price].Add(product);
        }

        private void AddProductsByTitle(string title, Product product)
        {
            this.data.ProductsByTitle.EnsureKeyExists(title);
            if (this.data.ProductsByTitle[title].Contains(product))
            {
                this.data.ProductsByTitle[title].Remove(product);
            }

            this.data.ProductsByTitle[title].Add(product);
        }

        private void AddProductsByTitleAndPrice(string title, decimal price, Product product)
        {
            var titleAndPrice = this.DoubleKey(title, price);
            this.data.ProductsByTitleAndPrice.EnsureKeyExists(titleAndPrice);
            if (this.data.ProductsByTitleAndPrice[titleAndPrice].Contains(product))
            {
                this.data.ProductsByTitleAndPrice[titleAndPrice].Remove(product);
            }

            this.data.ProductsByTitleAndPrice[titleAndPrice].Add(product);
        }

        private void AddProductByTitleAndPriceRange(string title, decimal price, Product product)
        {
            this.data.ProductsByTitleAndPriceRange.EnsureKeyExists(title);
            this.data.ProductsByTitleAndPriceRange[title].EnsureKeyExists(price);

            if (this.data.ProductsByTitleAndPriceRange[title][price].Contains(product))
            {
                this.data.ProductsByTitleAndPriceRange[title][price].Remove(product);
            }

            this.data.ProductsByTitleAndPriceRange[title][price].Add(product);
        }

        private void AddProductsBySupplierAndPrice(string supplier, decimal price, Product product)
        {
            var supplierAndPrice = this.DoubleKey(supplier, price);
            this.data.ProductsBySupplierAndPrice.EnsureKeyExists(supplierAndPrice);
            if (this.data.ProductsBySupplierAndPrice[supplierAndPrice].Contains(product))
            {
                this.data.ProductsBySupplierAndPrice[supplierAndPrice].Remove(product);
            }

            this.data.ProductsBySupplierAndPrice[supplierAndPrice].Add(product);
        }

        private void AddProductBySupplierAndPriceRange(string supplier, decimal price, Product product)
        {
            this.data.ProductsBySupplierAndPriceRange.EnsureKeyExists(supplier);
            this.data.ProductsBySupplierAndPriceRange[supplier].EnsureKeyExists(price);
            if (this.data.ProductsBySupplierAndPriceRange[supplier][price].Contains(product))
            {
                this.data.ProductsBySupplierAndPriceRange[supplier][price].Remove(product);
            }

            this.data.ProductsBySupplierAndPriceRange[supplier][price].Add(product);
        }

        private void RemoveProductById(int id)
        {
            this.data.ProductById.Remove(id);
        }

        private void RemoveProductsByPriceRange(Product product)
        {
            this.data.ProductsByPriceRange[product.Price].Remove(product);
            if (this.data.ProductsByPriceRange[product.Price].Count == 0)
            {
                this.data.ProductsByPriceRange.Remove(product.Price);
            }
        }

        private void RemoveProductsByTitle(Product product)
        {
            this.data.ProductsByTitle[product.Title].Remove(product);
            if (this.data.ProductsByTitle[product.Title].Count == 0)
            {
                this.data.ProductsByTitle.Remove(product.Title);
            }
        }

        private void RemoveProductsByTitleAndPrice(Product product)
        {
            var titleAndPrice = this.DoubleKey(product.Title, product.Price);
            this.data.ProductsByTitleAndPrice[titleAndPrice].Remove(product);
            if (this.data.ProductsByTitleAndPrice[titleAndPrice].Count == 0)
            {
                this.data.ProductsByTitleAndPrice.Remove(titleAndPrice);
            }
        }

        private void RemoveProductByTitleAndPriceRange(Product product)
        {
            this.data.ProductsByTitleAndPriceRange[product.Title][product.Price].Remove(product);
            if (this.data.ProductsByTitleAndPriceRange[product.Title][product.Price].Count == 0)
            {
                this.data.ProductsByTitleAndPriceRange[product.Title].Remove(product.Price);
            }

            if (this.data.ProductsByTitleAndPriceRange[product.Title].Count == 0)
            {
                this.data.ProductsByTitleAndPriceRange.Remove(product.Title);
            }
        }

        private void RemoveProductsBySupplierAndPrice(Product product)
        {
            var supplierAndPrice = this.DoubleKey(product.Supplier, product.Price);
            this.data.ProductsBySupplierAndPrice[supplierAndPrice].Remove(product);
            if (this.data.ProductsBySupplierAndPrice[supplierAndPrice].Count == 0)
            {
                this.data.ProductsBySupplierAndPrice.Remove(supplierAndPrice);
            }
        }

        private void RemoveProductBySupplierAndPriceRange(Product product)
        {
            this.data.ProductsBySupplierAndPriceRange[product.Supplier][product.Price].Remove(product);
            if (this.data.ProductsBySupplierAndPriceRange[product.Supplier][product.Price].Count == 0)
            {
                this.data.ProductsBySupplierAndPriceRange[product.Supplier].Remove(product.Price);
            }

            if (this.data.ProductsBySupplierAndPriceRange[product.Supplier].Count == 0)
            {
                this.data.ProductsBySupplierAndPriceRange.Remove(product.Supplier);
            }
        }

        private Tuple<string, decimal> DoubleKey(string str, decimal price)
        {
            return new Tuple<string, decimal>(str, price);
        }
    }
}