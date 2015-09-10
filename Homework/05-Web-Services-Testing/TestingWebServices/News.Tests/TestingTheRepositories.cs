namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Models;
    using News.Repositories;
    using News.Repositories.Interfaces;
    using News.Services.Models;

    [TestClass]
    public class TestingTheRepositories
    {
        private HttpClient client;

        private IUnitOfWorkData data;

        private FormUrlEncodedContent bodyDataPost;

        [TestInitialize]
        public void Initialize()
        {
            this.data = new UnitOfWorkData();

            this.client = new HttpClient();

            this.bodyDataPost = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Title", "Test One"),
                    new KeyValuePair<string, string>("Content", "Item for deleting"),
                    new KeyValuePair<string, string>("PublishDate", "1980-01-01")
                });
        }

        [TestMethod]
        public void ListAllNewsItemsShouldReturnsTheNewsItemsCorrectly()
        {
            var newsCount = this.data.News.GetAll().Count();

            HttpResponseMessage response = this.client.GetAsync("http://localhost:3208/api/news").Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            List<NewsViewModel> responseNews = response.Content.ReadAsAsync<List<NewsViewModel>>().Result;
            Assert.AreEqual(newsCount, responseNews.Count);
        }

        [TestMethod]
        public void CreateNewsItemWithCorrectDataShouldCreatesAndReturnsAnItem()
        {
            var response = this.client.PostAsync("http://localhost:3208/api/news", this.bodyDataPost).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseNewsItem = response.Content.ReadAsAsync<NewsItem>().Result;

            var expectedNewsItem = new NewsItem
                {
                    Title = "Test One",
                    Content = "Item for deleting", 
                    PublishDate = new DateTime(1980, 01, 01)
                };

            Assert.AreEqual(expectedNewsItem.Title, responseNewsItem.Title);
            Assert.AreEqual(expectedNewsItem.Content, responseNewsItem.Content);
            Assert.AreEqual(expectedNewsItem.PublishDate, responseNewsItem.PublishDate);

            var testNews = this.data.News.GetAll()
                .Where(n => n.Content == "Item for deleting")
                .ToList();

            Assert.AreNotEqual(0, testNews.Count);

            foreach (var newsItem in testNews)
            {
                this.data.News.Delete(newsItem);
            }

            this.data.SaveChanges();
        }

        [TestMethod]
        public void CreateNewsItemWithIncorrectDataShouldReturnBadRequest()
        {
            var response = this.client.PostAsync("http://localhost:3208/api/news", null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void ModifyExistingNewsItemWithCorrectDataShouldModifiesTheItem()
        {
            var postResponse = this.client.PostAsync("http://localhost:3208/api/news", this.bodyDataPost).Result;
            var postResponseNewsItem = postResponse.Content.ReadAsAsync<NewsItem>().Result;

            var newsItem = this.data.News.GetAll().FirstOrDefault(n => n.Content == postResponseNewsItem.Content);

            if (newsItem == null)
            {
                Assert.Fail("News not found.");
            }

            var bodyDataPut = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Title", "Test Two"), 
                    new KeyValuePair<string, string>("Content", "Item for deleting"), 
                    new KeyValuePair<string, string>("PublishDate", "1980-01-01")
                });

            var putResponse = this.client.PutAsync("http://localhost:3208/api/news/" + newsItem.Id, bodyDataPut).Result;
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);

            var putResponseNewsItems = putResponse.Content.ReadAsAsync<NewsItem>().Result;

            Assert.AreEqual("Test Two", putResponseNewsItems.Title);
            Assert.AreEqual("Item for deleting", putResponseNewsItems.Content);
            Assert.AreEqual(new DateTime(1980, 01, 01), putResponseNewsItems.PublishDate);

            var testNews = this.data.News.GetAll()
                .Where(n => n.Content == "Item for deleting")
                .ToList();

            Assert.AreNotEqual(0, testNews.Count);

            foreach (var news in testNews)
            {
                this.data.News.Delete(news);
            }

            this.data.SaveChanges();
        }

        [TestMethod]
        public void ModifyExistingNewsItemWithIncorrectDataShouldReturnBadRequest()
        {
            int id = this.data.News.GetAll().First().Id;

            var response = this.client.PutAsync("http://localhost:3208/api/news/" + id, null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void ModifyNonExistingNewsItemShouldReturnNotFound()
        {
            int id = -1;

            var response = this.client.PutAsync("http://localhost:3208/api/news/" + id, null).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void DeleteExistingNewsItemShouldDeletesTheItem()
        {
            var postResponse = this.client.PostAsync("http://localhost:3208/api/news", this.bodyDataPost).Result;
            var postResponseNewsItem = postResponse.Content.ReadAsAsync<NewsItem>().Result;

            var newsItem = this.data.News.GetAll().FirstOrDefault(n => n.Content == postResponseNewsItem.Content);

            if (newsItem == null)
            {
                Assert.Fail("News not found.");
            }

            var putResponse = this.client.DeleteAsync("http://localhost:3208/api/news/" + newsItem.Id).Result;
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);

            var deletedNewsItem = this.data.News.GetAll().FirstOrDefault(n => n.Id == newsItem.Id);
            Assert.AreEqual(null, deletedNewsItem);
        }

        [TestMethod]
        public void DeleteNonExistingNewsItemShouldReturnNotFound()
        {
            int id = -1;

            var response = this.client.DeleteAsync("http://localhost:3208/api/news/" + id).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}