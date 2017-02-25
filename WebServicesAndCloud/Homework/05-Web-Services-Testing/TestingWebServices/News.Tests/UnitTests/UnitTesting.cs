namespace News.Tests.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using News.Repositories.Interfaces;
    using News.Services.Controllers;
    using News.Services.Models;

    [TestClass]
    public class UnitTesting
    {
        private NewsController controller;

        private int fakeNewsCountBefore;

        private Mock<IUnitOfWorkData> mockContext;

        private MockContainer mocks;

        private NewsBindingModel newsItem;

        [TestInitialize]
        public void Initialize()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();

            this.mockContext = new Mock<IUnitOfWorkData>();
            this.mockContext.Setup(c => c.News).Returns(this.mocks.NewsRepositoryMock.Object);

            this.controller = new NewsController(this.mockContext.Object);
            this.controller.Request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost")
                };
            this.controller.Configuration = new HttpConfiguration();
            this.controller.Configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            this.newsItem = new NewsBindingModel
                {
                    Title = "New News", 
                    Content = "New News Content", 
                    PublishDate = DateTime.Now
                };

            this.fakeNewsCountBefore = this.mockContext.Object.News.GetAll().Count();
        }

        [TestMethod]
        public void GetAllNewsShouldReturnTotalNewsSortedByPublishDateDescending()
        {
            var fakeNews = this.mockContext.Object.News.GetAll()
                .OrderByDescending(n => n.PublishDate)
                .Select(n => n.Id)
                .ToList();

            var response = this.controller.GetNews().ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseNews = response.Content.ReadAsAsync<List<NewsViewModel>>().Result
                .Select(n => n.Id)
                .ToList();

            CollectionAssert.AreEqual(fakeNews, responseNews);
        }

        [TestMethod]
        public void CreateSingleNewsShouldSuccessfullyAddToRepository()
        {
            var response = this.controller.PostNewsItem(this.newsItem).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Once);

            var newsItemAfter = this.mocks.NewsFakeRepo.Last();
            Assert.AreEqual(this.fakeNewsCountBefore + 1, this.mocks.NewsFakeRepo.Count);
            Assert.AreEqual(this.newsItem.Title, newsItemAfter.Title);
            Assert.AreEqual(this.newsItem.Content, newsItemAfter.Content);
            Assert.AreEqual(this.newsItem.PublishDate, newsItemAfter.PublishDate);
        }

        [TestMethod]
        public void CreateNewsInvalidModelShouldReturn400BadRequest()
        {
            NewsBindingModel nullNewsItem = null;

            var responseTwo = this.controller.PostNewsItem(nullNewsItem).ExecuteAsync(CancellationToken.None).Result;
            Assert.AreEqual(HttpStatusCode.BadRequest, responseTwo.StatusCode);

            this.controller.ModelState.AddModelError("Title", "A value is required.");

            this.newsItem.Title = null;

            var responseOne = this.controller.PostNewsItem(this.newsItem).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, responseOne.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(this.fakeNewsCountBefore, this.mocks.NewsFakeRepo.Count);
        }

        [TestMethod]
        public void EditNewsCorrectDataShouldSuccessfullyAddToRepository()
        {
            var fakeNewsItem = this.mocks.NewsRepositoryMock.Object.GetAll().FirstOrDefault();

            var response = this.controller.EditNewsById(fakeNewsItem.Id, this.newsItem).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreEqual(this.newsItem.Title, this.mocks.NewsFakeRepo.First().Title);
            Assert.AreEqual(this.newsItem.Content, this.mocks.NewsFakeRepo.First().Content);
        }

        [TestMethod]
        public void EditNewsIncorrectDataShouldReturn400BadRequest()
        {
            var fakeNew = this.mocks.NewsRepositoryMock.Object.GetAll().FirstOrDefault();

            this.controller.ModelState.AddModelError("Title", "A value is required.");

            this.newsItem.Title = null;

            var response = this.controller.EditNewsById(fakeNew.Id, this.newsItem).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(fakeNew.Title, this.mocks.NewsFakeRepo.First().Title);
            Assert.AreEqual(fakeNew.Content, this.mocks.NewsFakeRepo.First().Content);
            Assert.AreEqual(fakeNew.PublishDate, this.mocks.NewsFakeRepo.First().PublishDate);
        }

        [TestMethod]
        public void EditNewsNonExistingIdShouldReturn404NotFound()
        {
            var response = this.controller.EditNewsById(-1, this.newsItem).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
        }

        [TestMethod]
        public void DeleteNewsExistingIdShouldReturn200Ok()
        {
            var fakeNew = this.mocks.NewsRepositoryMock.Object.GetAll().FirstOrDefault();

            var response = this.controller.DeleteNewsById(fakeNew.Id).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreEqual(this.fakeNewsCountBefore, this.mocks.NewsFakeRepo.Count);
        }

        [TestMethod]
        public void DeleteNewsNonExistingIdShouldReturn404NotFound()
        {
            var response = this.controller.DeleteNewsById(-1).ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            this.mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.AreEqual(this.fakeNewsCountBefore, this.mocks.NewsFakeRepo.Count);
        }
    }
}