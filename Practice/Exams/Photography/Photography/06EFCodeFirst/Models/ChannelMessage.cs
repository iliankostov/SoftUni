namespace Photography.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ChannelMessage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
        
        public DateTime MessageDateTime { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Chanel { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
