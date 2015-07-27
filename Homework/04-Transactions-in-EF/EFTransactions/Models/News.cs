namespace EFTransactions
{
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NewsContent { get; set; }
    }
}
