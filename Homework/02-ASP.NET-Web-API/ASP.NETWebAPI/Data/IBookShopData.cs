namespace Data
{
    using Data.Repositories;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public interface IBookShopData
    {
        IRepository<Author> Authors { get; }

        IRepository<Book> Books { get; }

        IRepository<Category> Categories { get; }

        IRepository<Purchase> Purchases { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<IdentityRole> Roles { get; } 

        void SaveChanges();
    }
}