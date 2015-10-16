namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Twitter.App.Constants;
    using Twitter.Models;

    public class UserSearchViewModel
    {
        public string Username { get; set; }

        public string ProfileImage { get; set; }

        public static Expression<Func<User, UserSearchViewModel>> Create()
        {
            return u => new UserSearchViewModel
                {
                    Username = u.UserName,
                    ProfileImage = u.ProfileImage ?? Constants.DefaultProfileImage
                };
        }
    }
}