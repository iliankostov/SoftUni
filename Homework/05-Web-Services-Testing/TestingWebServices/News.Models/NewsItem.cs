namespace News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}