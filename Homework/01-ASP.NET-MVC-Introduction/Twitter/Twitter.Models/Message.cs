namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}