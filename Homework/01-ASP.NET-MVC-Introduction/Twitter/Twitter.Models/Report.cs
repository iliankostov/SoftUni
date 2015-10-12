namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}