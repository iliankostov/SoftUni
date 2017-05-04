namespace AutomationTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using AutomationTests.Pages.DraggablePage;
    using AutomationTests.Utilities;

    [TestFixture]
    public class DemoQADraggableTests
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
            var draggablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            draggablePage.PerformDefaultDrag(offsetX, offsetY);

            //// Assert
            draggablePage.AssertDefaultDragIsPerformed(offsetX, offsetY);
        }

        [Test]
        public void DragElementWithConstraintMovementShouldProcessCorrectly()
        {
            //// Arrange 
            var draggablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            draggablePage.PerformConstraintMovementDrag(offsetX, offsetY);

            //// Assert
            draggablePage.AssertConstraintMovementDrag(offsetX, offsetY);
        }


        [Test]
        public void DragElementWithChangingCursorShouldProcessCorrectly()
        {
            //// Arrange 
            var draggablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            draggablePage.PerformDragWithCursorChange(offsetX, offsetY);

            //// Assert
            draggablePage.AssertDragWithCursorChange(offsetX, offsetY);
        }

        [Test]
        public void DragElementWithEventShouldProcessCorrectly()
        {
            //// Arrange 
            var draggablePage = new DraggablePage(this.driver);
            int offsetX = 100, offsetY = 100;

            //// Act
            draggablePage.PerformEventsDrag(offsetX, offsetY);

            //// Assert
            draggablePage.AssertEventsDrag(offsetX, offsetY);
        }

        [Test]
        public void DragAndSortElementShouldProcessCorrectly()
        {
            //// Arrange 
            var draggablePage = new DraggablePage(this.driver);
            int offsetX = 0, offsetY = 50;

            //// Act
            draggablePage.PerformDragAndSort(offsetX, offsetY);

            //// Assert
            draggablePage.AssertDragAndSort(offsetX, offsetY);
        }
    }
}