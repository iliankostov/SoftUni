namespace CollectionOfProducts
{
    using System.Collections.Generic;

    public interface IProductCollection
    {
        int Count { get; }

        Product Find(int id);

        void Add(int id, string title, string supplier, decimal price);

        bool Remove(int id);

        IEnumerable<Product> FindByPriceRange(decimal startPrice, decimal endPrice);

        IEnumerable<Product> FindByTitle(string title);

        IEnumerable<Product> FindByTitleAndPrice(string title, decimal price);

        IEnumerable<Product> FindByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice);

        IEnumerable<Product> FindBySupplierAndPrice(string supplier, decimal price);

        IEnumerable<Product> FindBySupplierAndPriceRange(string supplier, decimal startPrice, decimal endPrice);
    }
}