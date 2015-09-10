namespace OnlineShop.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using OnlineShop.Data.Repositories;
    using OnlineShop.Models;

    public class MockContainer
    {
        public Mock<IRepository<Ad>> AdRepositoryMock { get; set; }

        public Mock<IRepository<Category>> CategoryRepositoryMock { get; set; }

        public Mock<IRepository<AdType>> AdTypeRepositoryMock { get; set; }

        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public void PrepareMock()
        {
            this.SetupFakeCategories();
            this.SetupFakeUsers();
            this.SetupFakeAds();
            this.SetupFakeAdTypes();
        }

        private void SetupFakeAdTypes()
        {
            var fakeAdTypes = new List<AdType>
                {
                    new AdType { Name = "Normal", Index = 100 }, 
                    new AdType { Name = "Premium", Index = 200 }
                };

            this.AdTypeRepositoryMock = new Mock<IRepository<AdType>>();
            this.AdTypeRepositoryMock.Setup(r => r.All()).Returns(fakeAdTypes.AsQueryable());

            this.AdTypeRepositoryMock.Setup(r => r.Find(It.IsAny<int>())).Returns((int id) => fakeAdTypes[id]);
        }

        private void SetupFakeCategories()
        {
            var fakeCategories = new List<Category>
                {
                    new Category { Name = "Cars", Id = 1 }, 
                    new Category { Name = "Trucks", Id = 2 }
                };

            this.CategoryRepositoryMock = new Mock<IRepository<Category>>();
            this.CategoryRepositoryMock.Setup(r => r.All()).Returns(fakeCategories.AsQueryable());

            this.CategoryRepositoryMock.Setup(r => r.Find(It.IsAny<int>())).Returns((int id) => fakeCategories[id]);
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>
                {
                    new ApplicationUser { UserName = "Gosho", Id = "123" }, 
                    new ApplicationUser { UserName = "Pesho", Id = "456" }
                };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.All()).Returns(fakeUsers.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<int>())).Returns((int id) => fakeUsers[id]);
        }

        private void SetupFakeAds()
        {
            var adTypes = new List<AdType>
                {
                    new AdType { Name = "Normal", Index = 100 }, 
                    new AdType { Name = "Premium", Index = 200 }
                };

            var fakeAds = new List<Ad>
                {
                    new Ad
                        {
                            Id = 5, 
                            Status = AdStatus.Open, 
                            Name = "Audi A6", 
                            Type = adTypes[0], 
                            PostedOn = DateTime.Now.AddDays(-6), 
                            OwnerId = "123", 
                            Owner = new ApplicationUser { UserName = "Gosho", Id = "123" }, 
                            Price = 400
                        }, 
                    new Ad
                        {
                            Id = 6, 
                            Status = AdStatus.Open, 
                            Name = "Audi A4", 
                            Type = adTypes[1], 
                            PostedOn = DateTime.Now.AddDays(-5), 
                            OwnerId = "456", 
                            Owner = new ApplicationUser { UserName = "Pesho", Id = "456" }, 
                            Price = 500
                        }
                };

            this.AdRepositoryMock = new Mock<IRepository<Ad>>();
            this.AdRepositoryMock.Setup(r => r.All()).Returns(fakeAds.AsQueryable());

            this.AdRepositoryMock.Setup(r => r.Find(It.IsAny<int>())).Returns((int id) => fakeAds[id]);
        }
    }
}