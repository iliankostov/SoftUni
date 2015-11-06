namespace Snippy.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int SnippetId { get; set; }

        public virtual Snippet Snippet { get; set; }
    }
}