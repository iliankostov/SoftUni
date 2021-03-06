﻿namespace News.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class NewsBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}