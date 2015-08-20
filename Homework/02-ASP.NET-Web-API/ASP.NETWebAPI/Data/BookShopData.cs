namespace Data
{
    using System;
    using System.Collections.Generic;

    using Data.Repositories;

    using Models;

    public class BookShopData : IBookShopData
    {
        private IBookShopContext context;

        private IDictionary<Type, object> repositories;

        public BookShopData()
            : this(new BookShopContext())
        {
        }

        public BookShopData(IBookShopContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Author> Authors
        {
            get
            {
                return this.GetRepository<Author>();
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}