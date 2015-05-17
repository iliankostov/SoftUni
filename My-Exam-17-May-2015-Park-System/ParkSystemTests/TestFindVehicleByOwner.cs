namespace ParkSystemTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ParkSystem;

    [TestClass]
    public class TestFindVehicleByOwner
    {
        [TestMethod]
        public void InsertCarMustReturnCarParkedMessage()
        {
            var vehiclePark = new VehiclePark(1, 5);
            var car = new Car("CA1111HP", "ilian", 2);
            vehiclePark.InsertCar(car, 1, 1, new DateTime());
            var output = vehiclePark.FindVehiclesByOwner("ilian");
            string expected = @"Car [CA1111HP], owned by ilian
Parked at (1,1)";
            Assert.AreEqual(output, expected);
        }
    }
}
