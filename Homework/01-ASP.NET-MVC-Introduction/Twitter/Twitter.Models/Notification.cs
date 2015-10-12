namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Twitter.Models.Enumerations;

    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public NotificationType NotificationType { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}