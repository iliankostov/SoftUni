namespace AJAX.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Town
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}