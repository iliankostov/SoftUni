namespace Restaurants.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Restaurants.Data.Interfaces;
    using Restaurants.Services.Controllers;
    using Restaurants.Services.Models;

    [TestClass]
    public class RestaurantsControllerTests
    {
        private RestaurantsController controller;

        private Mock<IUnitOfWorkData> mockContext;

        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();

            this.mockContext = new Mock<IUnitOfWorkData>();
            this.mockContext.Setup(c => c.Restaurants).Returns(this.mocks.RestaurantRepositoryMock.Object);

            this.controller = new RestaurantsController(this.mockContext.Object);
            this.controller.Request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost")
                };
            this.controller.Configuration = new HttpConfiguration();
            this.controller.Configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
        }

        [TestMethod]
        public void GetAllRestaurantsByTownShouldReturnRestaurants()
        {
            var fakeRestaurants = this.mockContext.Object.Restaurants.GetAll()
                .Where(r => r.TownId == 1)
                .Select(n => n.Id)
                .ToList();

            var response = this.controller.GetRestaurantsByTown(1).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseNews = response.Content.ReadAsAsync<List<RestaurantViewModel>>().Result
                .Select(n => n.Id)
                .ToList();

            CollectionAssert.AreEqual(fakeRestaurants, responseNews);
        }
    }
}