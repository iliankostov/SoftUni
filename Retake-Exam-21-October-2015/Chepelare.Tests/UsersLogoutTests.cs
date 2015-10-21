namespace Chepelare.Tests
{
    using System;

    using Chepelare.Controllers;
    using Chepelare.Data;
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersLogoutTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotLogout()
        {
            var data = new HotelBookingSystemData();
            var controller = new UsersController(data, null);

            var view = controller.Logout();
        }

        [TestMethod]
        public void AuthorizedUserMustLogoutSuccessfully()
        {
            var user = new User("admin1", "admin1", Roles.VenueAdmin);
            var data = new HotelBookingSystemData();
            var controller = new UsersController(data, user);

            var view = controller.Logout();

            var expected = "The user admin1 has logged out.";
            Assert.AreEqual(expected, view.Display());
        }
    }
}