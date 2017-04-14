namespace AutomationTests.Pages.ResizeablePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class ResizeablePageMap
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ResizeablePageMap(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(Constants.WAIT_SECCONDS));
        }

       
    }
}
