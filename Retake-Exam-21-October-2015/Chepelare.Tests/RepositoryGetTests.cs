namespace Chepelare.Tests
{
    using Chepelare.Data;
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryGetTests
    {
        [TestMethod]
        public void GetVenueFromRepositoryMustReturnIt()
        {
            var user = new User("admin1", "admin1", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var expected = new Venue("one", "address one", "vanue with address one", user);
            data.RepositoryWithVenues.Add(expected);
            var actual = data.RepositoryWithVenues.Get(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIncorrectVenueFromRepositoryMustReturnNull()
        {
            var user = new User("admin1", "admin1", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var expected = new Venue("one", "address one", "vanue with address one", user);
            data.RepositoryWithVenues.Add(expected);
            var actual = data.RepositoryWithVenues.Get(2);

            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetRoomFromRepositoryMustReturnIt()
        {
            var data = new HotelBookingSystemData();
            var expected = new Room(2, 30.00m);
            data.RepositoryWithRooms.Add(expected);
            var actual = data.RepositoryWithRooms.Get(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIncorrectRoomFromRepositoryMustReturnNull()
        {
            var data = new HotelBookingSystemData();
            var expected = new Room(2, 30.00m);
            data.RepositoryWithRooms.Add(expected);
            var actual = data.RepositoryWithRooms.Get(2);

            Assert.AreEqual(null, actual);
        }
    }
}