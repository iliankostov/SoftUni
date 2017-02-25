namespace UnitTest
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Theatre;
    using Theatre.Exceptions;

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAddTheatres()
        {
            PerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre Sofia");
            database.AddTheatre("Theatre 199");
            int count = database.ListTheatres().Count();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        [ExpectedException(typeof (DuplicateTheatreException))]
        public void AddingDuplicateTheatreShouldThrowsDuplicateTheatreException()
        {
            PerformanceDatabase database = new PerformanceDatabase();
            database.AddTheatre("Theatre Sofia");
            database.AddTheatre("Theatre Sofia");
        }
    }
}