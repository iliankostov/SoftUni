namespace NewsDatabase
{
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string NewsContent { get; set; }
    }
}
