﻿namespace Twitter.App.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using PagedList;

    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
    using Twitter.Data.Contracts;
    using Twitter.Models;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        // GET: {username}/Tweets
        public ActionResult Index(string username, int? page)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var user =
                this.Data.Users.GetAll()
                    .Where(u => u.UserName == username)
                    .Select(UserViewModel.Create(currentUserId))
                    .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Index");
            }

            int pageSize = App.Constants.Constants.DefaultPageSize;
            int pageNumber = page ?? App.Constants.Constants.DefaultStartPage;

            IPagedList<TweetViewModel> tweets =
                this.Data.Tweets.GetAll()
                    .Where(u => u.AuthorId == user.Id)
                    .OrderByDescending(t => t.Date)
                    .Select(TweetViewModel.Create())
                    .ToPagedList(pageNumber, pageSize);

            var model = new UserAndTweetsViewModel()
                {
                    User = user,
                    TweetViewModels = tweets
                };

            return this.View(model);
        }

        // GET: {username}/Tweets/Favourite
        public ActionResult Favourite(string username)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var user =
                this.Data.Users.GetAll()
                    .Where(u => u.UserName == username)
                    .Select(UserViewModel.Create(currentUserId))
                    .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Favourite");
            }
            return this.View(user);
        }

        // GET: /Tweets/PostTweet
        [ChildActionOnly]
        public ActionResult PostTweet()
        {
            string currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var currentUser =
                this.Data.Users.GetAll()
                .Where(u => u.Id == currentUserId)
                .Select(UserViewModel.Create(currentUserId))
                .FirstOrDefault();

            var tweet = new PostTweetBindingModel
                {
                    Author = new UserViewModel { Username = currentUser.Username, ProfileImage = currentUser.ProfileImage },
                    Content = string.Empty
                };

            return this.PartialView("~/Views/Shared/_FormTweet.cshtml", tweet);
        }

        // POST: /Tweets/PostTweets
        [HttpPost]
        public async Task<ActionResult> PostTweet(PostTweetBindingModel model)
        {
            string currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var user = this.Data.Users.Find(currentUserId);

            if (this.ModelState.IsValid)
            {
                var newTweet = new Tweet
                    {
                        Content = model.Content,
                        PageUrl = string.Empty,
                        Date = DateTime.Now,
                        AuthorId = user.Id
                    };

                this.Data.Tweets.Add(newTweet);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index", "Home");
            }

            return this.PartialView("~/Views/Shared/_FormTweet.cshtml");
        }
    }
}