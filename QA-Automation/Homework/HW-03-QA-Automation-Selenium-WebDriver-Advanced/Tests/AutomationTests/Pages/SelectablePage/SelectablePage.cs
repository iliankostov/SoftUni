namespace AutomationTests.Pages.SelectablePage
{
    using OpenQA.Selenium;

    public class SelectablePage : BasePage<SelectablePageMap>
    {
        public SelectablePage(IWebDriver driver) : base(driver, new SelectablePageMap(driver))
        {
        }

        public override string Url
        {
            get
            {
                return Constants.SELECTABLE_URL;
            }
        }


    }
}
