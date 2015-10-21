namespace Chepelare.Tests
{
    using System;

    using Chepelare.Controllers;
    using Chepelare.Data;
    using Chepelare.Identity;
    using Chepelare.Models;
    using Chepelare.Models.Enumerations;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ControllerAuthorizeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotViewTheirProfile()
        {
            var data = new HotelBookingSystemData();
            var controller = new UsersController(data, null);
            var view = controller.MyProfile();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotViewVanuesDetails()
        {
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, null);
            var view = controller.Details(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotAddVenue()
        {
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, null);
            var view = controller.Add("venue one", "address one", "description one");
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AuthorizedUserCannotAddVenueIfHeIsNotAdminnistrator()
        {
            var user = new User("user12", "user12", Roles.User);
            var data = new HotelBookingSystemData();
            var controller = new VenuesController(data, user);
            var view = controller.Add("venue one", "address one", "description one");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotAddRoom()
        {
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, null);
            var view = controller.Add(1, 2, 30.00m);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AuthorizedUserCannotAddRoomIfHeIsNotAdminnistrator()
        {
            var user = new User("user12", "user12", Roles.User);
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, user);
            var view = controller.Add(1, 2, 30.00m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotAddPeriod()
        {
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, null);
            var view = controller.AddPeriod(1, DateTime.Now, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AuthorizedUserCannotAddPeriodIfHeIsNotAdminnistrator()
        {
            var user = new User("user12", "user12", Roles.User);
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, user);
            var view = controller.AddPeriod(1, DateTime.Now, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotViewBookings()
        {
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, null);
            var view = controller.ViewBookings(1);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AuthorizedUserCannotViewBookingsIfHeIsNotAdminnistrator()
        {
            var user = new User("user12", "user12", Roles.User);
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, user);
            var view = controller.ViewBookings(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnAuthorizedUserCannotBook()
        {
            var data = new HotelBookingSystemData();
            var controller = new RoomsController(data, null);
            var view = controller.Book(1, DateTime.Now, DateTime.Now, "comment one");
        }
    }
}