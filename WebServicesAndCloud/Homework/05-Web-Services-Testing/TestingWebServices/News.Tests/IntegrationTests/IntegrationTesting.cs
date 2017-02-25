namespace News.Tests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using EntityFramework.Extensions;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Models;
    using News.Repositories;
    using News.Services;
    using News.Services.Models;
    using Owin;

    [TestClass]
    public class IntegrationTesting
    {
        private HttpClient client;

        private NewsBindingModel invalidNewsItem;

        private NewsBindingModel newsItemOne;

        private NewsBindingModel newsItemTwo;

        private NewsItem newsOne;

        private TestServer testServer;

        [TestInitialize]
        public void Initialize()
        {
            // Start OWIN testing HTTP server with Web API support
            this.testServer = TestServer.Create(appBuilder =>
                {
                    var config = new HttpConfiguration();
                    WebApiConfig.Register(config);

                    var startup = new Startup();
                    startup.Configuration(appBuilder);

                    appBuilder.UseWebApi(config);
                });

            this.client = this.testServer.HttpClient;

            this.newsItemOne = new NewsBindingModel
                {
                    Title = "News One", 
                    Content = "News One Content", 
                    PublishDate = new DateTime(2015, 09, 11)
                };

            this.newsItemTwo = new NewsBindingModel
            {
                Title = "News Two",
                Content = "News Two Content",
                PublishDate = new DateTime(2015, 09, 10)
            };

            this.invalidNewsItem = new NewsBindingModel
                {
                    Title = null, 
                    Content = "Modified Content", 
                    PublishDate = new DateTime(2015, 09, 09)
                };

            this.PopulateDatabase();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var context = new NewsContext())
            {
                context.NewsItems.Delete();
                context.SaveChanges();
            }

            this.testServer.Dispose();
        }

        [TestMethod]
        public void GetAllNewsShouldReturns200OkAndAllNews()
        {
            var response = this.client.GetAsync("api/news").Result;
            var newsOneResponse = response.Content.ReadAsAsync<List<NewsItem>>().Result[0];

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(this.newsOne.Title, newsOneResponse.Title);
            Assert.AreEqual(this.newsOne.Content, newsOneResponse.Content);
            Assert.AreEqual(this.newsOne.PublishDate, newsOneResponse.PublishDate);
        }

        [TestMethod]
        public void CreateNewNewsItemShouldReturns201CreatedAndCreatedNewsItem()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var newsBody = this.GenerateBodyData(this.newsItemOne);

            var response = this.client.PostAsync("api/news", newsBody).Result;
            var newsTwoResponse = response.Content.ReadAsAsync<NewsItem>().Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(this.newsItemOne.Title, newsTwoResponse.Title);
            Assert.AreEqual(this.newsItemOne.Content, newsTwoResponse.Content);
            Assert.AreEqual(this.newsItemOne.PublishDate, newsTwoResponse.PublishDate);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count + 1, newsResponseAfter.Count);
        }

        [TestMethod]
        public void CreateIncorrectNewsItemShouldReturns400BadRequest()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var newsBody = this.GenerateBodyData(this.invalidNewsItem);

            var response = this.client.PostAsync("api/news", newsBody).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count, newsResponseAfter.Count);
        }

        [TestMethod]
        public void ModifyNewsItemShouldReturns200Ok()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var newsBody = this.GenerateBodyData(this.newsItemOne);

            var response = this.client.PutAsync("api/news/" + this.newsOne.Id, newsBody).Result;
            var modifiedNewsResponse = response.Content.ReadAsAsync<NewsItem>().Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(this.newsItemOne.Title, modifiedNewsResponse.Title);
            Assert.AreEqual(this.newsItemOne.Content, modifiedNewsResponse.Content);
            Assert.AreEqual(this.newsItemOne.PublishDate, modifiedNewsResponse.PublishDate);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count, newsResponseAfter.Count);
        }

        [TestMethod]
        public void ModifyNewsItemWithIncorrectDataShouldReturns400BadRequest()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var newsBody = this.GenerateBodyData(this.invalidNewsItem);

            var response = this.client.PostAsync("api/news/" + this.newsOne.Id, newsBody).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count, newsResponseAfter.Count);
        }

        [TestMethod]
        public void DeleteNewsItemShouldReturns200Ok()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var response = this.client.DeleteAsync("api/news/" + this.newsOne.Id).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count - 1, newsResponseAfter.Count);
        }

        [TestMethod]
        public void DeleteInvalidNewsItemShouldReturns404NotFound()
        {
            var responseBefore = this.client.GetAsync("api/news").Result;
            var newsResponseBefore = responseBefore.Content.ReadAsAsync<List<NewsItem>>().Result;

            var response = this.client.DeleteAsync("api/news/-1").Result;
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var responseAfter = this.client.GetAsync("api/news").Result;
            var newsResponseAfter = responseAfter.Content.ReadAsAsync<List<NewsItem>>().Result;

            Assert.AreEqual(newsResponseBefore.Count, newsResponseAfter.Count);
        }

        private void PopulateDatabase()
        {
            var newsBodyOne = this.GenerateBodyData(this.newsItemOne);
            var newsBodyTwo = this.GenerateBodyData(this.newsItemTwo);

            var newsOneResponse = this.client.PostAsync("api/news", newsBodyOne).Result;
            var newsTwoResponse = this.client.PostAsync("api/news", newsBodyTwo).Result;

            this.newsOne = newsOneResponse.Content.ReadAsAsync<NewsItem>().Result;
        }

        private FormUrlEncodedContent GenerateBodyData(NewsBindingModel news)
        {
            var newsBody = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("title", news.Title), 
                    new KeyValuePair<string, string>("content", news.Content), 
                    new KeyValuePair<string, string>("publishDate", news.PublishDate.ToString(CultureInfo.InvariantCulture))
                });
            return newsBody;
        }
    }
}