﻿namespace Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public interface IBookShopContext
    {
        IDbSet<Author> Authors { get; set; }

        IDbSet<Book> Books { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Purchase> Purchases { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntry> Entry<TEntry>(TEntry entry) where TEntry : class;
    }
}