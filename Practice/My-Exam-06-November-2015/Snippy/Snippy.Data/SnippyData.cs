namespace Snippy.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Snippy.Data.Contracts;
    using Snippy.Models;

    public class SnippyData : ISnippyData
    {
        private DbContext context;

        private Dictionary<Type, object> repositories;

        public SnippyData()
            : this(new SnippyContext())
        {
        }

        public SnippyData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Snippet> Snippets
        {
            get
            {
                return this.GetRepository<Snippet>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Language> Languages
        {
            get
            {
                return this.GetRepository<Language>();
            }
        }

        public IRepository<Label> Labels
        {
            get
            {
                return this.GetRepository<Label>();
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