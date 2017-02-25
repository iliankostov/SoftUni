namespace Service.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RoleBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}