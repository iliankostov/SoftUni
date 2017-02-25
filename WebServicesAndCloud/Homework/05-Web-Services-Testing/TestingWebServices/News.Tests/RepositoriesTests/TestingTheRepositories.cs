namespace News.Tests.RepositoriesTests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using EntityFramework.Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Models;
    using News.Repositories;
    using News.Repositories.Interfaces;

    [TestClass]
    public class TestingTheRepositories
    {
        private IUnitOfWorkData data;

        private IList<NewsItem> news;

        [TestInitialize]
        public void Initialize()
        {
            this.data = new UnitOfWorkData();

            this.news = new List<NewsItem>
                {
                    new NewsItem
                        {
                            Title = "News One", 
                            Content = "News One Content", 
                            PublishDate = new DateTime(2013, 01, 01)
                        }, 
                    new NewsItem
                        {
                            Title = "News Two", 
                            Content = "News Two Content", 
                            PublishDate = new DateTime(2014, 01, 01)
                        }, 
                    new NewsItem
                        {
                            Title = "News Three", 
                            Content = "News Three Content", 
                            PublishDate = new DateTime(2015, 01, 01)
                        }
                };

            foreach (var newsItem in this.news)
            {
                this.data.News.Add(newsItem);
            }

            this.data.SaveChanges();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var context = new NewsContext())
            {
                context.NewsItems.Delete();
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void ListAllNewsItemsShouldReturnsTheNewsItemsCorrectly()
        {
            var dataNews = this.data.News.GetAll().ToList();

            Assert.AreEqual(this.news.Count, dataNews.Count);
            Assert.AreEqual(this.news[0].Title, dataNews[0].Title);
            Assert.AreEqual(this.news[1].Content, dataNews[1].Content);
            Assert.AreEqual(this.news[2].PublishDate, dataNews[2].PublishDate);
        }

        [TestMethod]
        public void CreateNewsItemWithCorrectDataShouldCreatesAndReturnsAnItem()
        {
            var newsItem = new NewsItem
                {
                    Title = "New News", 
                    Content = "New News Content", 
                    PublishDate = new DateTime(2015, 09, 09)
                };

            this.data.News.Add(newsItem);
            this.data.SaveChanges();

            var createdItem = this.data.News.GetAll()
                .FirstOrDefault(n =>
                                n.Title == newsItem.Title &&
                                n.Content == newsItem.Content &&
                                n.PublishDate == newsItem.PublishDate);

            if (createdItem == null)
            {
                Assert.Fail("Items is not created");
            }

            Assert.AreEqual(createdItem.Title, newsItem.Title);
            Assert.AreEqual(createdItem.Content, newsItem.Content);
            Assert.AreEqual(createdItem.PublishDate, newsItem.PublishDate);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]

        public void CreateNewsItemWithIncorrectDataShouldReturnBadRequest()
        {
            NewsItem invalidNewsItem = new NewsItem
                {
                    Content = "Content",
                    PublishDate = DateTime.Now
                };

            this.data.News.Add(invalidNewsItem);
            this.data.SaveChanges();
        }

        [TestMethod]
        public void ModifyExistingNewsItemWithCorrectDataShouldModifiesTheItem()
        {
            var newsItem = this.data.News.GetAll().FirstOrDefault();

            if (newsItem != null)
            {
                newsItem.Title = "Modified Title";
            }

            this.data.SaveChanges();

            var modifiedNewsItem = this.data.News.GetAll().FirstOrDefault(n => n.Id == newsItem.Id);

            Assert.AreEqual(newsItem.Title, modifiedNewsItem.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ModifyExistingNewsItemWithIncorrectDataShouldReturnBadRequest()
        {
            var newsItem = this.data.News.GetAll().FirstOrDefault();

            if (newsItem != null)
            {
                newsItem.Title = null;
            }

            this.data.SaveChanges();
        }

        [TestMethod]
        public void ModifyNonExistingNewsItemShouldReturnNotFound()
        {
            var newsItem = this.data.News.GetAll().FirstOrDefault(n => n.Title == "no name");

            Assert.AreEqual(null, newsItem);
        }

        [TestMethod]
        public void DeleteExistingNewsItemShouldDeletesTheItem()
        {
            var newsItem = this.data.News.GetAll().FirstOrDefault(n => n.Title == "News One");

            this.data.News.Delete(newsItem);
            this.data.SaveChanges();
            var newsAfter = this.data.News.GetAll().FirstOrDefault(n => n.Title == "News One");
            
            Assert.AreEqual(this.news.Count - 1, this.data.News.GetAll().Count());
            Assert.AreEqual(null, newsAfter);
        }

        [TestMethod]
        public void DeleteNonExistingNewsItemShouldReturnNotFound()
        {
            var newsItem = this.data.News.GetAll().FirstOrDefault(n => n.Title == "no name");

            Assert.AreEqual(null, newsItem);
        }
    }
}