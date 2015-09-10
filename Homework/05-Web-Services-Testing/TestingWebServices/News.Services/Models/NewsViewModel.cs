namespace News.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using News.Models;

    public class NewsViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public static Expression<Func<NewsItem, NewsViewModel>> Create()
        {
            return n => new NewsViewModel()
                {
                    Title = n.Title,
                    Content = n.Content,
                    PublishDate = n.PublishDate
                };
        }
    }
}