namespace AJAX.App.Models
{
    using System;
    using System.Linq.Expressions;

    using AJAX.Models;

    public class UserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Town { get; set; }

        public StatusType StatusType { get; set; }

        public int? Age { get; set; }

        public static Expression<Func<User, UserViewModel>> Create()
        {
            return u => new UserViewModel()
                {
                    Username = u.UserName,
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    Town = u.Town.Name,
                    StatusType = u.StatusType,
                    Age = u.Age
                };
        }
    }
}