namespace Service.Models
{
    using System.Collections.Generic;

    using global::Models.Enumerations;

    public class BookViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public string AuthorName { get; set; }

        public ICollection<string> CategoriesNames { get; set; }

        public ICollection<string> RelatedBooksNames { get; set; }
    }
}