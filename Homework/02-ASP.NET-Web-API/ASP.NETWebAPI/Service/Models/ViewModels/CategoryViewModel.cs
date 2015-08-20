namespace Service.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using global::Models;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> Create
        {
            get
            {
                return c => new CategoryViewModel
                                {
                                    Id = c.Id, 
                                    Name = c.Name
                                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}