namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using AutomationTests.Pages.DraggablePage;
    using AutomationTests.Utilities;

    [TestFixture]
    public class DemoQADragableTests
    {
        private IWebDriver driver;

        [SetUp]
        public void BeforeEachTest()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterEachTest()
        {
            this.driver.Log().Quit();
        }

        [Test]
        public void DragItemShouldChangeItsPosition()
        {
            //// Arrange 
            var dragablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            dragablePage.PerformDefaultDrag(offsetX, offsetY);

            //// Assert
            dragablePage.AssertDefaultDragIsPerformed(offsetX, offsetY);
        }

        [Test]
        public void DragElementWithConstraintMovementShouldProcessCorrectly()
        {
            //// Arrange 
            var dragablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            dragablePage.PerformConstraintMovementDrag(offsetX, offsetY);

            //// Assert
            dragablePage.AssertConstraintMovementDrag(offsetX, offsetY);
        }


        [Test]
        public void DragElementWithChangingCursorShouldProcessCorrectly()
        {
            //// Arrange 
            var dragablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            dragablePage.PerformDragWithCursorChange(offsetX, offsetY);

            //// Assert
            dragablePage.AssertDragWithCursorChange(offsetX, offsetY);
        }

        [Test]
        public void DragElementWithEventShouldProcessCorrectly()
        {
            //// Arrange 
            var dragablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            dragablePage.PerformEventsDrag(offsetX, offsetY);

            //// Assert
            dragablePage.AssertEventsDrag(offsetX, offsetY);
        }

        [Test]
        public void DragAndSortElementShouldProcessCorrectly()
        {
            //// Arrange 
            var dragablePage = new DraggablePage(this.driver);
            int offsetX = 0, offsetY = 50;

            //// Act
            dragablePage.PerformDragAndSort(offsetX, offsetY);

            //// Assert
            dragablePage.AssertDragAndSort(offsetX, offsetY);
        }
    }
}