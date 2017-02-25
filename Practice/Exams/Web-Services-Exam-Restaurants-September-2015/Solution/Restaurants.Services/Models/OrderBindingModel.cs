namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderBindingModel
    {
        [Required]
        public int Quantity { get; set; }
    }
}