namespace AutomationTests.Pages.DragablePage
{
    using OpenQA.Selenium;

    public class DragablePage : BasePage<DragablePageMap>
    {
        public DragablePage(IWebDriver driver) : base(driver, new DragablePageMap(driver))
        {
        }

        public override string Url
        {
            get
            {
                return Constants.DRAGABLE_URL;
            }
        }


    }
}
