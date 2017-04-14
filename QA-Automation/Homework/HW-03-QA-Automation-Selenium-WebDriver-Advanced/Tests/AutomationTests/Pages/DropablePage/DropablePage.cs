namespace AutomationTests.Pages.DropablePage
{
    using OpenQA.Selenium;

    public class DropablePage : BasePage<DropablePageMap>
    {
        public DropablePage(IWebDriver driver) : base(driver, new DropablePageMap(driver))
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
