namespace Restaurants.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using Restaurants.Data.Interfaces;
    using Restaurants.Models;

    public class MockContainer
    {
        public Mock<IRepository<ApplicationUser>> UserRepositoryMock { get; set; }

        public IList<ApplicationUser> UsersFakeRepo { get; set; }

        public Mock<IRepository<Town>> TownRepositoryMock { get; set; }

        public IList<Town> TownFakeRepo { get; set; }

        public Mock<IRepository<Restaurant>> RestaurantRepositoryMock { get; set; }

        public IList<Restaurant> ResaurantFakeRepo { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeUsers();
            this.SetupFakeTown();
            this.SetupFakeRestaurants();
        }

        private void SetupFakeTown()
        {
            this.TownFakeRepo = new List<Town>
                {
                    new Town
                        {
                            Id = 1, 
                            Name = "Sofia"
                        }, 
                    new Town
                        {
                            Id = 2, 
                            Name = "Plovdiv"
                        }
                };

            this.TownRepositoryMock = new Mock<IRepository<Town>>();
            this.TownRepositoryMock.Setup(r => r.GetAll())
                .Returns(this.TownFakeRepo.AsQueryable());

            this.TownRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                    {
                        var town = this.TownFakeRepo.FirstOrDefault(a => a.Id == id);
                        return town;
                    });

            this.TownRepositoryMock
                .Setup(r => r.Add(It.IsAny<Town>()))
                .Callback((Town town) => { this.TownFakeRepo.Add(town); });
        }

        private void SetupFakeUsers()
        {
            var fakeUsers = new List<ApplicationUser>
                {
                    new ApplicationUser { UserName = "Uti", Id = "123" }, 
                    new ApplicationUser { UserName = "Guest", Id = "456" }
                };

            this.UserRepositoryMock = new Mock<IRepository<ApplicationUser>>();
            this.UserRepositoryMock.Setup(r => r.GetAll()).Returns(fakeUsers.AsQueryable());

            this.UserRepositoryMock.Setup(r => r.Find(It.IsAny<int>())).Returns((int id) => fakeUsers[id]);
        }

        private void SetupFakeRestaurants()
        {
            this.ResaurantFakeRepo = new List<Restaurant>
                {
                    new Restaurant
                        {
                            Id = 1, 
                            TownId = 1, 
                            Name = "Pru uti1", 
                            OwnerId = "123"
                        }, 
                    new Restaurant
                        {
                            Id = 2, 
                            TownId = 1, 
                            Name = "Pru uti2", 
                            OwnerId = "123"
                        }
                };

            this.RestaurantRepositoryMock = new Mock<IRepository<Restaurant>>();
            this.RestaurantRepositoryMock.Setup(r => r.GetAll())
                .Returns(this.ResaurantFakeRepo.AsQueryable());

            this.RestaurantRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                    {
                        var restaurant = this.ResaurantFakeRepo.FirstOrDefault(a => a.Id == id);
                        return restaurant;
                    });

            this.RestaurantRepositoryMock
                .Setup(r => r.Add(It.IsAny<Restaurant>()))
                .Callback((Restaurant restaurant) => { this.ResaurantFakeRepo.Add(restaurant); });
        }
    }
}