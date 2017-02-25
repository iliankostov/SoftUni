namespace Chepelare.Tests
{
    using System.Text;

    using Chepelare.Controllers;
    using Chepelare.Data;
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VanuesAllTests
    {
        [TestMethod]
        public void GetAllVanuesWithoutDataMustReturnNoVanues()
        {
            var user = new User("admin1", "admin1", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, user);
            var vanues = controller.All();

            var expected = "There are currently no venues to show.";

            Assert.AreEqual(expected, vanues.Display());
        }

        [TestMethod]
        public void GetAllVanuesWithDataMustReturnThem()
        {
            var user = new User("admin1", "admin1", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var venue = new Venue("one", "address one", "vanue with address one", user);
            data.RepositoryWithVenues.Add(venue);

            var controller = new VenuesController(data, user);
            var vanues = controller.All();

            var expected = new StringBuilder();
            expected.AppendFormat("*[{0}] {1}, located at {2}", venue.Id, venue.Name, venue.Address)
                    .AppendLine()
                    .AppendFormat("Free rooms: {0}", venue.Rooms.Count);

            Assert.AreEqual(expected.ToString(), vanues.Display());
        }
    }
}