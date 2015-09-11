namespace News.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using News.Models;
    using News.Repositories.Interfaces;

    public class MockContainer
    {
        public Mock<IRepository<NewsItem>> NewsRepositoryMock { get; set; }

        public IList<NewsItem> NewsFakeRepo { get; set; }

        public void PrepareMocks()
        {
            this.SetupFakeNews();
        }

        private void SetupFakeNews()
        {
            this.NewsFakeRepo = new List<NewsItem>
                {
                    new NewsItem
                        {
                            Id = 1, 
                            Title = "News One", 
                            Content = "News One Content", 
                            PublishDate = DateTime.Now.AddDays(-1)
                        }, 
                    new NewsItem
                        {
                            Id = 2, 
                            Title = "News Two", 
                            Content = "News Two Content", 
                            PublishDate = DateTime.Now.AddDays(-2)
                        }
                };

            this.NewsRepositoryMock = new Mock<IRepository<NewsItem>>();
            this.NewsRepositoryMock.Setup(r => r.GetAll())
                .Returns(this.NewsFakeRepo.AsQueryable());

            this.NewsRepositoryMock.Setup(r => r.Find(It.IsAny<int>()))
                .Returns((int id) =>
                    {
                        var ad = this.NewsFakeRepo.FirstOrDefault(a => a.Id == id);
                        return ad;
                    });

            this.NewsRepositoryMock
                .Setup(r => r.Add(It.IsAny<NewsItem>()))
                .Callback((NewsItem news) => { this.NewsFakeRepo.Add(news); });
        }
    }
}