namespace Restaurants.Tests.IntegrationTests
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Owin;
    using Restaurants.Data;
    using Restaurants.Services;
    using Restaurants.Services.Models;
    using Restaurants.Tests.Models;

    [TestClass]
    public class MealsIntegrationTests
    {
        private HttpClient client;

        private RestaurantsContext context;

        private TestServer testServer;

        [TestInitialize]
        public void Initialize()
        {
            // Start OWIN testing HTTP server with Web API support
            this.testServer = TestServer.Create(appBuilder =>
                {
                    var config = new HttpConfiguration();
                    WebApiConfig.Register(config);

                    var startup = new Startup();
                    startup.Configuration(appBuilder);

                    appBuilder.UseWebApi(config);
                });

            this.client = this.testServer.HttpClient;

            this.context = new RestaurantsContext();

            this.PopulateDatabase();
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.context.Meals.Delete();

            this.context.Restaurants.Delete();

            this.context.Users.Delete();

            this.client.DefaultRequestHeaders.Clear();

            this.testServer.Dispose();
        }

        [TestMethod]
        public void EditExistingMealShouldEditMealCorrectlly()
        {
            var loginData = this.Login("uti");
            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var meal = this.context.Meals.FirstOrDefault();
            if (meal == null)
            {
                Assert.Fail("No meals in the database.");
            }

            var type = meal.Type;

            var editMeal = new EditMealBindingModel
                {
                    Name = "Meal One", 
                    Price = 1M, 
                    TypeId = type.Id
                };

            var editMealBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", editMeal.Name), 
                    new KeyValuePair<string, string>("price", editMeal.Price.ToString(CultureInfo.InvariantCulture)), 
                    new KeyValuePair<string, string>("typeId", editMeal.TypeId.ToString())
                });

            var editMealResponse = this.client.PutAsync("api/meals/" + meal.Id, editMealBody).Result;
            var mealResponse = editMealResponse.Content.ReadAsAsync<MealViewModel>().Result;

            Assert.AreEqual(editMeal.Name, mealResponse.Name);
            Assert.AreEqual(editMeal.Price, mealResponse.Price);
            Assert.AreEqual(type.Name, mealResponse.Type);

            // Clean headers
            this.client.DefaultRequestHeaders.Remove("Authorization");
        }

        [TestMethod]
        public void EditNonExistingMealShouldReturn404NotFound()
        {
            var loginData = this.Login("uti");
            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var meal = this.context.Meals.FirstOrDefault();
            if (meal == null)
            {
                Assert.Fail("No meals in the database.");
            }

            var editMealResponse = this.client.PutAsync("api/meals/" + meal.Id, null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, editMealResponse.StatusCode);

            // Clean headers
            this.client.DefaultRequestHeaders.Remove("Authorization");
        }

        [TestMethod]
        public void EditExistingMealWithInvalidDataShouldReturn400BadRequest()
        {
            var loginData = this.Login("uti");
            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            var meal = this.context.Meals.FirstOrDefault();
            if (meal == null)
            {
                Assert.Fail("No meals in the database.");
            }

            var type = meal.Type;

            var editMeal = new EditMealBindingModel
                {
                    Name = "Meal One", 
                    Price = 1M, 
                    TypeId = type.Id
                };

            var editMealBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", editMeal.Name), 
                    new KeyValuePair<string, string>("price", editMeal.Price.ToString(CultureInfo.InvariantCulture)), 
                    new KeyValuePair<string, string>("typeId", editMeal.TypeId.ToString())
                });

            var editMealResponse = this.client.PutAsync("api/meals/-1", editMealBody).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, editMealResponse.StatusCode);

            // Clean headers
            this.client.DefaultRequestHeaders.Remove("Authorization");
        }

        [TestMethod]
        public void EditExistingMealUnauthorizedShouldReturn401Unauthorize()
        {
            var meal = this.context.Meals.FirstOrDefault();
            if (meal == null)
            {
                Assert.Fail("No meals in the database.");
            }

            var type = meal.Type;

            var editMeal = new EditMealBindingModel
                {
                    Name = "Meal One", 
                    Price = 1M, 
                    TypeId = type.Id
                };

            var editMealBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", editMeal.Name), 
                    new KeyValuePair<string, string>("price", editMeal.Price.ToString(CultureInfo.InvariantCulture)), 
                    new KeyValuePair<string, string>("typeId", editMeal.TypeId.ToString())
                });

            var editMealResponse = this.client.PutAsync("api/meals/" + meal.Id, editMealBody).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, editMealResponse.StatusCode);
        }

        private void PopulateDatabase()
        {
            // Register
            this.Register("uti");
            this.Register("guest");

            // Login
            var loginData = this.Login("uti");

            this.client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginData.Access_Token);

            // Create Restaurant
            var restaurant = new RestaurantBindingModel
                {
                    Name = "Pri uti", 
                    TownId = 2
                };

            var restaurantBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", restaurant.Name), 
                    new KeyValuePair<string, string>("townId", restaurant.TownId.ToString())
                });

            var restaurantResponse = this.client.PostAsync("api/restaurants", restaurantBody).Result;
            var restaurantId = restaurantResponse.Content.ReadAsAsync<RestaurantViewModel>().Result.Id;

            // Create Meals
            var mealOne = new CreateMealBindingModel
                {
                    Name = "musaka", 
                    Price = 4.5M, 
                    TypeId = 3, 
                    RestaurantId = restaurantId
                };

            var mealTwo = new CreateMealBindingModel
                {
                    Name = "tarator", 
                    Price = 2.5M, 
                    TypeId = 2, 
                    RestaurantId = restaurantId
                };

            var mealOneBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", mealOne.Name), 
                    new KeyValuePair<string, string>("price", mealOne.Price.ToString(CultureInfo.InvariantCulture)), 
                    new KeyValuePair<string, string>("typeId", mealOne.TypeId.ToString()), 
                    new KeyValuePair<string, string>("restaurantId", mealOne.RestaurantId.ToString())
                });

            var mealTwoBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("name", mealTwo.Name), 
                    new KeyValuePair<string, string>("price", mealTwo.Price.ToString(CultureInfo.InvariantCulture)), 
                    new KeyValuePair<string, string>("typeId", mealTwo.TypeId.ToString()), 
                    new KeyValuePair<string, string>("restaurantId", mealTwo.RestaurantId.ToString())
                });

            var mealOneResponse = this.client.PostAsync("api/meals", mealOneBody).Result;
            var mealTwoResponse = this.client.PostAsync("api/meals", mealTwoBody).Result;

            // Clean headers
            this.client.DefaultRequestHeaders.Remove("Authorization");
        }

        private void Register(string username)
        {
            var registerContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username), 
                    new KeyValuePair<string, string>("password", "123456"), 
                    new KeyValuePair<string, string>("confirmPassword", "123456"), 
                    new KeyValuePair<string, string>("email", username + "@abv.bg")
                });

            var httpResponse = this.client.PostAsync("api/account/register", registerContent).Result;
        }

        private LoginData Login(string username)
        {
            var loginContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username), 
                    new KeyValuePair<string, string>("password", "123456"), 
                    new KeyValuePair<string, string>("grant_type", "password")
                });

            var httpResponse = this.client.PostAsync("api/account/login", loginContent).Result;

            return httpResponse.Content.ReadAsAsync<LoginData>().Result;
        }
    }
}