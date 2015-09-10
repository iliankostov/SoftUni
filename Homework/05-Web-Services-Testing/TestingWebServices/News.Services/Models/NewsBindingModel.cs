namespace News.Services.Models
{
    using System;

    public class NewsBindingModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}