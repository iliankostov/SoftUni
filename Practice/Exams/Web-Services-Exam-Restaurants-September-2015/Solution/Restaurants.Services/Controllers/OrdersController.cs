namespace Restaurants.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using Restaurants.Data.Interfaces;
    using Restaurants.Models;

    public class OrdersController : BaseController
    {
        public OrdersController()
        {
        }

        public OrdersController(IUnitOfWorkData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult ViewPendingOrders([FromUri] int startPage, [FromUri] int limit, [FromUri] int mealId)
        {
            var userId = this.User.Identity.GetUserId();

            var orders = this.Data.Orders.GetAll()
                .Where(o => o.UserId == userId && o.OrderStatus == OrderStatus.Pending && o.MealId == mealId)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(startPage)
                .Take(limit)
                .Select(o => new
                    {
                        o.Id, 
                        Meal = new
                            {
                                Id = o.MealId, 
                                Name = o.Meal.Name, 
                                Price = o.Meal.Price, 
                                Type = o.Meal.Type.Name
                            }, 
                        Quantity = o.Quantity, 
                        Status = o.OrderStatus, 
                        CreatedOn = o.CreatedOn
                    });

            return this.Ok(orders);
        }
    }
}