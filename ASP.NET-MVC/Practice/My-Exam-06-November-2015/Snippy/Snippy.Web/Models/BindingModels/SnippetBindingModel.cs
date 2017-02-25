namespace Snippy.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class SnippetBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Code { get; set; }

        public string AuthorUserName { get; set; }

        [Required]
        public string Labels { get; set; }

        [Required]
        public string Language { get; set; }
    }
}