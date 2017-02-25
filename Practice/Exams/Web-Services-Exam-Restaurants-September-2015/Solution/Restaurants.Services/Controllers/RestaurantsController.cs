namespace Restaurants.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Restaurants.Data.Interfaces;
    using Restaurants.Models;
    using Restaurants.Services.Models;

    public class RestaurantsController : BaseController
    {
        public RestaurantsController()
        {
        }

        public RestaurantsController(IUnitOfWorkData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetRestaurantsByTown([FromUri] int townId)
        {
            var restaurants = this.Data.Restaurants.GetAll()
                .Where(r => r.TownId == townId)
                .OrderByDescending(r => r.Ratings.Average(s => s.Stars))
                .ThenBy(r => r.Name)
                .Select(RestaurantViewModel.Create());

            return this.Ok(restaurants);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult CreateRestaurant(RestaurantBindingModel restaurantBindingModel)
        {
            var ownerId = this.User.Identity.GetUserId();

            if (restaurantBindingModel == null)
            {
                return this.BadRequest("Data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newRestaurant = new Restaurant
                {
                    Name = restaurantBindingModel.Name, 
                    TownId = restaurantBindingModel.TownId, 
                    OwnerId = ownerId
                };

            this.Data.Restaurants.Add(newRestaurant);
            this.Data.SaveChanges();

            var restaurantView = this.Data.Restaurants.GetAll()
                .Where(r => r.Id == newRestaurant.Id)
                .Select(RestaurantViewModel.Create())
                .FirstOrDefault();

            var uriLocation = new
                {
                    controller = "restaurants", 
                    id = newRestaurant.Id
                };

            return this.CreatedAtRoute("DefaultApi", uriLocation, restaurantView);
        }

        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult RateRestaurant(int id, RatingBindingModel ratingBindingModel)
        {
            var userId = this.User.Identity.GetUserId();

            var restaurant = this.Data.Restaurants.GetAll().FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (ratingBindingModel == null)
            {
                return this.BadRequest("Data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (restaurant.OwnerId == userId)
            {
                return this.BadRequest("Owner cannot rate its restaurants.");
            }

            var rating = this.Data.Ratings.GetAll()
                .FirstOrDefault(r => r.UserId == userId && r.RestaurantId == restaurant.Id);

            if (rating == null)
            {
                rating = new Rating
                    {
                        Stars = ratingBindingModel.Stars, 
                        UserId = userId, 
                        RestaurantId = restaurant.Id
                    };

                this.Data.Ratings.Add(rating);
            }
            else
            {
                rating.Stars = ratingBindingModel.Stars;
            }

            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            var restaurant = this.Data.Restaurants.GetAll().FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            var restaurantMeals = this.Data.Meals.GetAll()
                .Where(m => m.RestaurantId == id)
                .Select(MealViewModel.Create());

            return this.Ok(restaurantMeals);
        }
    }
}