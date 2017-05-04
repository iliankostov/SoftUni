namespace AutomationTests.Pages.ResizeablePage
{
    using OpenQA.Selenium;

    public class ResizeablePage : BasePage<ResizeablePageMap>
    {
        public ResizeablePage(IWebDriver driver) : base(driver, new ResizeablePageMap(driver))
        {
        }

        public override string Url
        {
            get
            {
                return Constants.RESIZEABLE_URL;
            }
        }


    }
}
