namespace AutomationTests.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;

    public static class DriverExtensions
    {
        public static void Type(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickOnElements(this List<IWebElement> elements, string data)
        {
            var conditions = data.Split(',').Select(int.Parse).ToList();

            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i] == 1)
                {
                    elements[i].Click();
                }
            }
        }

        public static string ToAbsolutePath(this string relativePath)
        {
            return Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, relativePath));
        }

        public static IWebDriver Log(this IWebDriver driver)
        {
            var today = DateTime.Now.Date.ToShortDateString().Replace('/', '-');
            var dirPath = ConfigurationManager.AppSettings["logsPath"].ToAbsolutePath() + today;
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            var logPath = $"{dirPath}\\{today}.log";
            var logger = GetLogger(logPath);

            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
                {
                    logger.Log(NLog.LogLevel.Error, TestContext.CurrentContext.Result.Message);

                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile($"{dirPath}\\{TestContext.CurrentContext.Test.Name}.jpg", ScreenshotImageFormat.Jpeg);
                }
                else
                {
                    logger.Log(NLog.LogLevel.Trace, TestContext.CurrentContext.Result.Outcome.Status);
                }
            }
            catch (Exception ex)
            {
                logger.Log(NLog.LogLevel.Fatal, ex);
            }

            return driver;
        }

        private static Logger GetLogger(string logPath)
        {
            var logConfig = new LoggingConfiguration();
            var target = new FileTarget
            {
                Name = "file",
                FileName = logPath
            };
            logConfig.AddTarget(target);
            var rule = new LoggingRule("*", NLog.LogLevel.Trace, target);
            logConfig.LoggingRules.Add(rule);
            LogManager.Configuration = logConfig;
            return LogManager.GetLogger(TestContext.CurrentContext.Test.Name);
        }
    }
}
