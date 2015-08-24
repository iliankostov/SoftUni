namespace Service.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using global::Models;

    public class AuthorViewModel
    {
        public static Expression<Func<Author, AuthorViewModel>> Create
        {
            get
            {
                return a => new AuthorViewModel()
                                {
                                    Id = a.Id,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName
                                };
            }
        }

        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}