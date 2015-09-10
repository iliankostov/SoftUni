namespace News.Repositories
{
    using System;
    using System.Collections.Generic;
    using News.Models;
    using News.Repositories.Interfaces;

    public class UnitOfWorkData : IUnitOfWorkData
    {
        private NewsContext context;

        private IDictionary<Type, object> repositories;

        public UnitOfWorkData()
            : this(new NewsContext())
        {
        }

        public UnitOfWorkData(NewsContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<NewsItem> News
        {
            get
            {
                return this.GetRepository<NewsItem>();
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