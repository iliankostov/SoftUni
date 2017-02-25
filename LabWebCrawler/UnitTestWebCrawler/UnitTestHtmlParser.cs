using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCrawler.Core;
using WebCrawler.Common;

namespace UnitTestWebCrawler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    [TestClass]
    public class UnitTestHtmlParser
    {
        private HtmlParser htmlParser;

        private const string fourRandomImages = "<img src=\"/Files/Publications/2015/02/SoftUni-Conf-March-2015-news_173441400.jpg\" width=\"250\" height=\"100\" alt=\"SoftUni Conf March 2015 - Пампорово, 20-22 март image\"> <img src=\"/Files/Publications/2015/02/softuni-council-apply_17296273.jpg\" width=\"250\" height=\"100\" alt=\"Предстоят избори за студентски съвет в СофтУни image\"> <img src=\"/Files/Publications/2015/02/Programming-Basics-SoftUni-Lab-march-2015_12269736.jpg\" width=\"250\" height=\"100\" alt=\"Нов безплатен курс по &quot;Основи на програмирането&quot; започва от 28 март image\">  <img src=\"/Files/Publications/2015/02/Hristo-Tenchev-Svetlin-Nakov-SoftUni-news_15284984.jpg\" width=\"250\" height=\"100\" alt=\"СофтУни спечели награда на БАИТ за образование image\">";

        private const string threeRandomAnchors = "<a title=\"Edit profile\" href=\"/Users/Profile/Edit/\"> <a title=\"Manage\" href=\"/Account/Manage/\"> <a title=\"Teamwork\" href=\"/Users/Teamwork/List/\">";

        [TestInitialize]
        public void Initialize()
        {
            htmlParser = new HtmlParser();
        }

        [TestMethod]
        public void ParseAnchorsShouldRetrieveAllHtmlAnchorTagReferences()
        {          
            var expectedOutputAnchors = new List<string>()
            {
                "/Account/Manage/",
                "/Users/Profile/Edit/",             
                "/Users/Teamwork/List/"
            };

            var outputAnchors = htmlParser.ParseAnchors(threeRandomAnchors).ToList();

            Assert.AreEqual(expectedOutputAnchors.Count(), outputAnchors.Count());

            CollectionAssert.AreEqual(expectedOutputAnchors.OrderBy(e => e).ToList(), outputAnchors.OrderBy(o => o).ToList());
        }

        [TestMethod]
        public void ParseImagesShouldRetrieveAllHtmlImageTagReferences()
        {           

            var expectedOutputImages = new List<string>()
            {
                "/Files/Publications/2015/02/SoftUni-Conf-March-2015-news_173441400.jpg",
                "/Files/Publications/2015/02/softuni-council-apply_17296273.jpg",
                "/Files/Publications/2015/02/Programming-Basics-SoftUni-Lab-march-2015_12269736.jpg",
                "/Files/Publications/2015/02/Hristo-Tenchev-Svetlin-Nakov-SoftUni-news_15284984.jpg"
            };

            var outputImages = htmlParser.ParseImages(fourRandomImages).ToList();

            Assert.AreEqual(expectedOutputImages.Count(), outputImages.Count());

            CollectionAssert.AreEqual(expectedOutputImages.OrderBy(e => e).ToList(), outputImages.OrderBy(o => o).ToList());
        }

        [TestMethod]
        public void TestMatchCollectionExtension()
        {
            var patern = ".*?([a-z\\s]+)([0-9])";
            Regex regex = new Regex(patern);
            string inputText = "this is match 1 this is match 2 this is match 3 this is match 4 this is match 5";

            var matches = regex.Matches(inputText);

            var output = Extensions.GroupsAsEnumerable(matches, 2).ToList();
            var expectedOutput = new List<string>() {"1","2","3","4","5"};

            CollectionAssert.AreEqual(expectedOutput, output);
        }
    }
}