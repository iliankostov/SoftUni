namespace Service.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using global::Models;
    using global::Models.Enumerations;

    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> Create
        {
            get
            {
                return b => new BookViewModel
                                {
                                    Id = b.Id, 
                                    Title = b.Title, 
                                    Description = b.Description, 
                                    EditionType = b.EditionType, 
                                    AgeRestriction = b.AgeRestriction, 
                                    Price = b.Price, 
                                    Copies = b.Copies, 
                                    ReleaseDate = b.ReleaseDate, 
                                    Author = new AuthorViewModel
                                                 {
                                                     Id = b.AuthorId,
                                                     FirstName = b.Author.FirstName, 
                                                     LastName = b.Author.LastName
                                                 }, 
                                    Categories = b.Categories.Select(c => c.Name)
                                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AuthorViewModel Author { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}