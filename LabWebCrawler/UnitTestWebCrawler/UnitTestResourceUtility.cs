using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCrawler.Common;

namespace UnitTestWebCrawler
{
    [TestClass]
    public class UnitTestResourceUtility
    {
        [TestMethod]
        public void TestHttpResourceValidatorShouldReturnTrueForHttps()
        {
            string input = "https:\\/\\/softuni.bg\\/";

            Assert.IsTrue(ResourceUtility.IsValidHttpResource(input));
        }

        [TestMethod]
        public void TestImageValidatorShouldReturnTrueForValidImageExtensions()
        {
            string input = "SoftUni-Conf-March-2015-news_173441400.png";

            Assert.IsTrue(ResourceUtility.IsValidImage(input));
        }

        // TODO: I have no time sorry!
        [TestMethod]
        public void TestGetValidResourceString()
        {
            string url = "https:\\/\\/softuni.bg\\/Files\\/Publications\\/2015\\/02\\/";
            string image = "SoftUni-Conf-March-2015-news_173441400.jpg";

            string output = ResourceUtility.GetValidResourceString(url, image);

            Assert.AreEqual(url + image, output);
        }
    }
}