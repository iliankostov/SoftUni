namespace Service.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}