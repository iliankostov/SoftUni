namespace CollectionOfProducts.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionOfProductsTests
    {
        private IProductCollection products;

        [TestInitialize]
        public void TestInitialize()
        {
            this.products = new ProductCollection();
        }

        [TestMethod]
        [Timeout(250)]
        public void TestPerformanceAddProduct()
        {
            this.AddProducts(5000);
            Assert.AreEqual(5000, this.products.Count);
        }

        [TestMethod]
        public void TestPerformanceFindProduct()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 5000; i++)
            {
                var existingProduct = this.products.Find(i);
                Assert.IsNotNull(existingProduct);

                var nonExistingProduct = this.products.Find(5050);
                Assert.IsNull(nonExistingProduct);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformanceFindProductsByTitleAndPrice()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.FindByTitleAndPrice("product0", 0).ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindByTitleAndPrice("product0", 90).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(450)]
        public void TestPerformanceFindProductsByPriceRange()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 2000; i++)
            {
                var existingProducts =
                    this.products.FindByPriceRange(51, 55).ToList();
                Assert.AreEqual(250, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindByPriceRange(110, 150).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformanceFindProductsByTitleAndPriceRange()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.FindByTitleAndPriceRange("product1", 0, 20).ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindByTitleAndPriceRange("product1", 10, 20).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformanceFindProductsByTitle()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.FindByTitle("product1").ToList();
                Assert.AreEqual(1, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindByTitle("non-existing product").ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformanceFindProductsBySupplierAndPrice()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 10000; i++)
            {
                var existingProducts =
                    this.products.FindBySupplierAndPrice("supplier1", 1).ToList();
                Assert.AreEqual(50, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindBySupplierAndPrice("supplier1", 50).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(250)]
        public void TestPerformanceFindProductsBySupplierAndPriceRange()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 2000; i++)
            {
                var existingProducts =
                    this.products.FindBySupplierAndPriceRange("supplier1", 0, 20).ToList();
                Assert.AreEqual(50, existingProducts.Count);

                var notExistingProducts =
                    this.products.FindBySupplierAndPriceRange("supplier1", 50, 60).ToList();

                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformanceRemoveProductById()
        {
            this.AddProducts(5000);

            for (int i = 0; i < 5000; i++)
            {
                bool hasRemovedExistingProduct =
                    this.products.Remove(i);
                Assert.IsTrue(hasRemovedExistingProduct);

                bool hasRemovedNonExistingProduct =
                    this.products.Remove(5050);

                Assert.IsFalse(hasRemovedNonExistingProduct);
            }
        }

        private void AddProducts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.products.Add(i, "product" + i, "supplier" + (i % 100), i % 100);
            }
        }
    }
}