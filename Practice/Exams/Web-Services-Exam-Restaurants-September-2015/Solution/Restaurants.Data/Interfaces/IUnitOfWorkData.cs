namespace Restaurants.Data.Interfaces
{
    using Restauranteur.Models;
    using Restaurants.Models;

    public interface IUnitOfWorkData
    {
        IRepository<Rating> Ratings { get; }

        IRepository<Town> Towns { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        void SaveChanges();
    }
}