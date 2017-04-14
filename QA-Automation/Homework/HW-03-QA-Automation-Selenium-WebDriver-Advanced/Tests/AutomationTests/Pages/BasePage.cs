namespace AutomationTests.Pages
{
    using OpenQA.Selenium;
    using System.Configuration;

    public abstract class BasePage<T> where T : class
    {
        public BasePage(IWebDriver driver, T elements)
        {
            this.Driver = driver;
            this.Elements = elements;
        }

        public IWebDriver Driver { get; private set; }

        public T Elements { get; private set; }

        public abstract string Url { get; }

        public virtual void Open(string part = "")
        {
            var domain = ConfigurationManager.AppSettings["domain"];
            this.Driver.Navigate().GoToUrl($"{domain}{this.Url}{part}");
        }
    }
}
