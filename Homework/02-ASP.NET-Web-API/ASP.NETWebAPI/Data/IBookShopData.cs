namespace Data
{
    using Data.Repositories;

    using Models;

    public interface IBookShopData
    {
        IRepository<Author> Authors { get; }

        IRepository<Book> Books { get; }

        IRepository<Category> Categories { get; }

        void SaveChanges();
    }
}