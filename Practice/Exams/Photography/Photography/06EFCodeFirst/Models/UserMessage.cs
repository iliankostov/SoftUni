namespace Photography.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserMessages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime MessageDateTime { get; set; }

        public int RecipientUserId { get; set; }

        public User RecipientUser { get; set; }

        public int SenderUserId { get; set; }

        public User SenderUser { get; set; }
    }
}
