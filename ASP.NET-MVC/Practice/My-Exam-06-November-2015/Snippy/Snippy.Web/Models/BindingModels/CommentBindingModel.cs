namespace Snippy.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        [Required]
        public int SnippetId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}