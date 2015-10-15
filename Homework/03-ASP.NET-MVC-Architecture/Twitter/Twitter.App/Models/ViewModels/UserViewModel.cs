namespace Twitter.App.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using Constants;

    using Twitter.Models;

    public class UserViewModel
    {
        public string Username { get; set; }

        public string ProfileImage { get; set; }

        public string CoverImage { get; set; }

        public static Expression<Func<User, UserViewModel>> Create()
        {
            return
                u =>
                new UserViewModel
                    {
                        Username = u.UserName,
                        ProfileImage = u.ProfileImage ?? Constants.DefaultProfileImage,
                        CoverImage = u.CoverImage ?? Constants.DefaultCoverImage
                    };
        }
    }
}