namespace Restaurants.Services.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Restaurants.Models;

    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create()
        {
            return r => new RestaurantViewModel
                {
                    Id = r.Id, 
                    Name = r.Name, 
                    Rating = r.Ratings.Average(s => s.Stars), 
                    Town = new TownViewModel
                        {
                            Id = r.TownId, 
                            Name = r.Town.Name
                        }
                };
        }
    }
}