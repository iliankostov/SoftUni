namespace ParkSystemTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ParkSystem.Models;

    [TestClass]
    public class InsertCarTest
    {
        [TestMethod]
        public void InsertCarMustReturnCarParkedMessage()
        {
            var vehiclePark = new VehiclePark(1, 5);
            var car = new Car("CA1111HP", "ilian", 2);
            var output = vehiclePark.InsertCar(car, 1, 1, new DateTime());
            string expected = "Car parked successfully at place (1,1)";
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void TestIfCarCanBePlacedAtWrongSector()
        {
            var vehiclePark = new VehiclePark(1, 1);
            var car = new Car("CA1111HP", "ilian", 2);
            var output = vehiclePark.InsertCar(car, 2, 1, new DateTime());
            string expected = "There is no sector 2 in the park";
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void TestIfCarCanBePlacedAtWrongPlace()
        {
            var vehiclePark = new VehiclePark(1, 1);
            var car = new Car("CA1111HP", "ilian", 2);
            var output = vehiclePark.InsertCar(car, 1, 2, new DateTime());
            string expected = "There is no place 2 in sector 1";
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void TestIfCarCanBePlacedAtOcupiedPlace()
        {
            var vehiclePark = new VehiclePark(1, 2);
            var carOne = new Car("CA1111HP", "ilian", 2);
            var carTwo = new Car("CA1112HP", "ilian", 2);
            vehiclePark.InsertCar(carOne, 1, 1, new DateTime());
            var output = vehiclePark.InsertCar(carTwo, 1, 1, new DateTime());
            string expected = "The place (1,1) is occupied";
            Assert.AreEqual(output, expected);
        }
    }
}