namespace Restaurants.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Restaurants.Data.Interfaces;
    using Restaurants.Models;
    using Restaurants.Services.Models;

    public class MealsController : BaseController
    {
        public MealsController()
        {
        }

        public MealsController(IUnitOfWorkData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult CreateNewMeal(CreateMealBindingModel mealBindingModel)
        {
            var userId = this.User.Identity.GetUserId();

            if (mealBindingModel == null)
            {
                return this.BadRequest("Data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.Data.Restaurants.GetAll().FirstOrDefault(r => r.Id == mealBindingModel.RestaurantId);

            if (restaurant == null)
            {
                return this.BadRequest("Invalid restaurant data");
            }

            if (userId != restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            var newMeal = new Meal
                {
                    Name = mealBindingModel.Name, 
                    Price = mealBindingModel.Price, 
                    TypeId = mealBindingModel.TypeId, 
                    RestaurantId = mealBindingModel.RestaurantId
                };
            this.Data.Meals.Add(newMeal);
            this.Data.SaveChanges();

            var mealView = this.Data.Meals.GetAll()
                .Where(m => m.Id == newMeal.Id)
                .Select(MealViewModel.Create())
                .FirstOrDefault();

            var uriLocation = new
                {
                    controller = "meals", 
                    id = newMeal.Id
                };

            return this.CreatedAtRoute("DefaultApi", uriLocation, mealView);
        }

        [HttpPut]
        public IHttpActionResult EditMeal(int id, EditMealBindingModel mealBindingModel)
        {
            var userId = this.User.Identity.GetUserId();

            if (mealBindingModel == null)
            {
                return this.BadRequest("Data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var meal = this.Data.Meals.GetAll().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return this.NotFound();
            }

            if (userId != meal.Restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            meal.Name = mealBindingModel.Name;
            meal.Price = mealBindingModel.Price;
            meal.TypeId = mealBindingModel.TypeId;

            this.Data.SaveChanges();

            var mealView = this.Data.Meals.GetAll()
                .Where(m => m.Id == meal.Id)
                .Select(MealViewModel.Create())
                .FirstOrDefault();

            return this.Ok(mealView);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMeal(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var meal = this.Data.Meals.GetAll().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return this.NotFound();
            }

            if (userId != meal.Restaurant.OwnerId)
            {
                return this.Unauthorized();
            }

            this.Data.Meals.Delete(meal);
            this.Data.SaveChanges();

            return this.Ok(string.Format("Meal #{0} deleted.", meal.Id));
        }

        [HttpPost]
        [Route("api/meals/{id}/order")]
        [Authorize]
        public IHttpActionResult CreateOrder(int id, OrderBindingModel orderBindingModel)
        {
            var userId = this.User.Identity.GetUserId();

            if (orderBindingModel == null)
            {
                return this.BadRequest("Data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var meal = this.Data.Meals.GetAll().FirstOrDefault(m => m.Id == id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var newOrder = new Order
                {
                    MealId = meal.Id, 
                    Quantity = orderBindingModel.Quantity, 
                    UserId = userId, 
                    CreatedOn = DateTime.Now, 
                    OrderStatus = OrderStatus.Pending
                };

            this.Data.Orders.Add(newOrder);
            this.Data.SaveChanges();

            return this.Ok(string.Format("Your order number is #{0}", newOrder.Id));
        }
    }
}