namespace AJAX.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using AJAX.Data.Contracts;
    using AJAX.Models;

    public class AjaxData : IAjaxData
    {
        private DbContext context;

        private Dictionary<Type, object> repositories;

        public AjaxData()
            : this(new AjaxContext())
        {
        }

        public AjaxData(DbContext context)
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

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
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