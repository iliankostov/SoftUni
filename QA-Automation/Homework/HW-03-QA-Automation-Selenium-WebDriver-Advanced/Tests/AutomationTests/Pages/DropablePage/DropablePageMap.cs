namespace AutomationTests.Pages.DropablePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class DropablePageMap
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public DropablePageMap(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(Constants.WAIT_SECCONDS));
        }

       
    }
}
