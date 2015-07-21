namespace EntityFrameworkCodeFirst
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
