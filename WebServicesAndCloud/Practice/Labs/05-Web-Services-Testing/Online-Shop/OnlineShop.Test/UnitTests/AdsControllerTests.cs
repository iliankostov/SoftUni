namespace OnlineShop.Test.UnitTests
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
    using OnlineShop.Data;
    using OnlineShop.Models;
    using OnlineShop.Service.Controllers;
    using OnlineShop.Service.Infrastructure;
    using OnlineShop.Service.Models.BindingModels;
    using OnlineShop.Service.Models.ViewModels;

    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMock();
        }

        [TestMethod]
        public void GetAllAds_Should_Return_Total_Ads_Sorted_By_TypeIndex()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads).Returns(this.mocks.AdRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);
            this.SetupController(adsController);

            var response = adsController.GetAds().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var adsResponse = response.Content.ReadAsAsync<IEnumerable<AdViewModel>>().Result
                .Select(a => a.Id)
                .ToList();

            var orderedFakeAds = fakeAds
                .OrderByDescending(a => a.Type.Index)
                .ThenBy(a => a.PostedOn)
                .Select(a => a.Id)
                .ToList();

            CollectionAssert.AreEqual(orderedFakeAds, adsResponse);
        }

        [TestMethod]
        public void CreateAd_Should_Successfully_Add_To_Repository()
        {
            var ads = new List<Ad>();

            var fakeUser = this.mocks.UserRepositoryMock.Object.All().FirstOrDefault();
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                    {
                        ad.Owner = fakeUser;
                        ads.Add(ad);
                    });

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);
            mockContext.Setup(c => c.AdTypes)
                .Returns(this.mocks.AdTypeRepositoryMock.Object);
            mockContext.Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);
            mockContext.Setup(c => c.Categories)
                .Returns(this.mocks.CategoryRepositoryMock.Object);

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);
            this.SetupController(adsController);

            var randomName = Guid.NewGuid().ToString();
            var newAd = new AdBindingModel
                {
                    Name = randomName, 
                    Price = 555, 
                    TypeId = 1, 
                    Description = "No description", 
                    Categories = new[] { 1 }
                };

            var response = adsController.CreateAd(newAd).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            mockContext.Verify(c => c.SaveChanges(), Times.Once);

            Assert.AreEqual(1, ads.Count);
            Assert.AreEqual(randomName, ads[0].Name);
        }

        [TestMethod]
        public void Close_Ad_As_Owner_Should_Successfully_Change_Ad_Status()
        {
            var fakeAd = this.mocks.AdRepositoryMock.Object.All().FirstOrDefault(a => a.Status == AdStatus.Open);
            if (fakeAd == null)
            {
                Assert.Fail("Cannot perform test - no ad available.");
            }

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var fakeUser = this.mocks.UserRepositoryMock.Object.All().FirstOrDefault(u => u.Id == fakeAd.Owner.Id);
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);
            this.SetupController(adsController);

            var response = adsController.CloseAd(fakeAd.Id).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreNotEqual(null, fakeAd.ClosedOn);
            Assert.AreEqual(AdStatus.Closed, fakeAd.Status);
        }

        [TestMethod]
        public void Close_Ad_As_Non_Owner_Should_Return_400_Bad_Request()
        {
            var fakeAd = this.mocks.AdRepositoryMock.Object.All().FirstOrDefault(a => a.Status == AdStatus.Open);
            if (fakeAd == null)
            {
                Assert.Fail("Cannot perform test - no ad available.");
            }

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var fakeUser = this.mocks.UserRepositoryMock.Object.All().FirstOrDefault(u => u.Id != fakeAd.OwnerId);
            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no user available.");
            }

            var mockIdProvider = new Mock<IUserIdProvider>();
            mockIdProvider.Setup(ip => ip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockIdProvider.Object);
            this.SetupController(adsController);

            var response = adsController.CloseAd(fakeAd.Id).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(AdStatus.Open, fakeAd.Status);
        }

        private void SetupController(AdsController adsController)
        {
            adsController.Request = new HttpRequestMessage();
            adsController.Configuration = new HttpConfiguration();
        }
    }
}