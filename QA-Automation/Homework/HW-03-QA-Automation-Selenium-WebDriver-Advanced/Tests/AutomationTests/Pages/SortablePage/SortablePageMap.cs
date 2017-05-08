namespace AutomationTests.Pages.SortablePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class SortablePageMap
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SortablePageMap(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(Constants.WAIT_SECCONDS));
        }

        public IWebElement DefaultTab
        {
            get
            {
                this.wait.Until(ExpectedConditions.ElementExists(By.Id(Constants.DEFAULT_TAB_SELECTOR)));
                return this.driver.FindElement(By.Id(Constants.DEFAULT_TAB_SELECTOR));
            }
        }
    }
}
