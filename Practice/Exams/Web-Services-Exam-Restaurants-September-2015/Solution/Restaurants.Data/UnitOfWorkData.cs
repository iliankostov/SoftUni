namespace Restaurants.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Restauranteur.Models;
    using Restaurants.Data.Interfaces;
    using Restaurants.Models;

    public class UnitOfWorkData : IUnitOfWorkData
    {
        private DbContext context;

        private IDictionary<Type, object> repositories;

        public UnitOfWorkData()
            : this(new RestaurantsContext())
        {
        }

        public UnitOfWorkData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Rating> Ratings
        {
            get
            {
                return this.GetRepository<Rating>();
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.GetRepository<Town>();
            }
        }

        public IRepository<Restaurant> Restaurants
        {
            get
            {
                return this.GetRepository<Restaurant>();
            }
        }

        public IRepository<Meal> Meals
        {
            get
            {
                return this.GetRepository<Meal>();
            }
        }

        public IRepository<MealType> MealTypes
        {
            get
            {
                return this.GetRepository<MealType>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
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