namespace AutomationTests.Pages.SelectablePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class SelectablePageMap
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SelectablePageMap(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(Constants.WAIT_SECCONDS));
        }

       
    }
}
