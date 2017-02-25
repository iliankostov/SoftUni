namespace ParkSystemTests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ParkSystem.Models;

    [TestClass]
    public class ExitVehicleTest
    {
        [TestMethod]
        public void TestIfExitVehicleReturnPrintedTicket()
        {
            var vehiclePark = new VehiclePark(1, 5);
            var car = new Car("CA1111HP", "ilian", 2);
            vehiclePark.InsertCar(car, 1, 1, new DateTime());
            var output = vehiclePark.ExitVehicle("CA1111HP", new DateTime(), 40M);
            string expected = @"********************
Car [CA1111HP], owned by ilian
at place (1,1)
Rate: $4.00
Overtime rate: $0.00
--------------------
Total: $4.00
Paid: $40.00
Change: $36.00
********************";
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void TestIfWrongExitVehicleReturnMessage()
        {
            var vehiclePark = new VehiclePark(1, 5);
            var car = new Car("CA1111HP", "ilian", 2);
            vehiclePark.InsertCar(car, 1, 1, new DateTime());
            var output = vehiclePark.ExitVehicle("CA1112HP", new DateTime(), 40M);
            string expected = "There is no vehicle with license plate CA1112HP in the park";
            Assert.AreEqual(output, expected);
        }
    }
}