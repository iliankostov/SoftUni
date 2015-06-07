namespace ParkSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using ParkSystem.Models;

    [TestClass]
    public class GetStatusTest
    {
        [TestMethod]
        public void TestGetStatusOutputMessage()
        {
            var vehiclePark = new VehiclePark(3, 5);

            var output = vehiclePark.GetStatus();

            string expected = @"Sector 1: 0 / 5 (0% full)
Sector 2: 0 / 5 (0% full)
Sector 3: 0 / 5 (0% full)";
            Assert.AreEqual(output, expected);
        }
    }
}