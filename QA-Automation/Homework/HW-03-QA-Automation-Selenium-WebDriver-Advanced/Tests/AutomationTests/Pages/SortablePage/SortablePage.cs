namespace AutomationTests.Pages.SortablePage
{
    using OpenQA.Selenium;

    public class SortablePage : BasePage<SortablePageMap>
    {
        public SortablePage(IWebDriver driver) : base(driver, new SortablePageMap(driver))
        {
        }

        public override string Url
        {
            get
            {
                return Constants.SORTABLE_URL;
            }
        }


    }
}
