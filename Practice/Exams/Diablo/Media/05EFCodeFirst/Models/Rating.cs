namespace Movies.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 10)]
        public int Stars { get; set; }

        public virtual User User { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
