namespace OnlineShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using OnlineShop.Data.Repositories;
    using OnlineShop.Models;

    public class OnlineShopData : IOnlineShopData
    {
        private DbContext context;

        private IDictionary<Type, object> repositories;

        public OnlineShopData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Ad> Ads
        {
            get
            {
                return this.GetRepositorues<Ad>();
            }
        }

        public IRepository<AdType> AdTypes
        {
            get
            {
                return this.GetRepositorues<AdType>();
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepositorues<Category>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepositorues<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public int SaveChangesAsync()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepositorues<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}