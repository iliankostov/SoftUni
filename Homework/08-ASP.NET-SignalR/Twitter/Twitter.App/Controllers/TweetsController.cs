﻿namespace Twitter.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.SignalR;

    using PagedList;

    using Twitter.App.Hubs;
    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
    using Twitter.App.Utilities;
    using Twitter.Data.Contracts;
    using Twitter.Models;
    using Twitter.Models.Enumerations;

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

            int pageSize = DefaultValues.DefaultPageSize;
            int pageNumber = page ?? DefaultValues.DefaultStartPage;

            IPagedList<TweetViewModel> tweets =
                this.Data.Tweets.GetAll()
                    .Where(t => t.AuthorId == user.Id || t.RetweetedBy.Any(u => u.Id == user.Id))
                    .OrderByDescending(t => t.Date)
                    .Select(TweetViewModel.Create())
                    .ToPagedList(pageNumber, pageSize);

            var model = new UserAndTweetsViewModel() { User = user, TweetViewModels = tweets };

            return this.View(model);
        }

        // GET: {username}/Tweets/Favourite
        [System.Web.Mvc.Authorize]
        public ActionResult Favourite(string username, int? page)
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

            int pageSize = DefaultValues.DefaultPageSize;
            int pageNumber = page ?? DefaultValues.DefaultStartPage;

            IPagedList<TweetViewModel> tweets =
                this.Data.Tweets.GetAll()
                    .Where(t => t.FavoritedBy.Any(ft => ft.Id == user.Id))
                    .OrderByDescending(t => t.Date)
                    .Select(TweetViewModel.Create())
                    .ToPagedList(pageNumber, pageSize);

            var model = new UserAndTweetsViewModel() { User = user, TweetViewModels = tweets };

            return this.View(model);
        }

        // GET: /Tweets/PostTweet
        [ChildActionOnly]
        public ActionResult PostTweet(ManageMessageId? message)
        {
            this.ViewBag.StatusMessage = message == ManageMessageId.PostTweetSucess
                                             ? "Successfully tweet"
                                             : message == ManageMessageId.Error
                                                   ? "Incorrect data. Please try again."
                                                   : "";

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
        public ActionResult PostTweet(PostTweetBindingModel model)
        {
            string currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

            var user = this.Data.Users.Find(currentUserId);

            if (!this.ModelState.IsValid)
            {
                return this.Content("Tweet error!");
                //return this.RedirectToAction("Index", "Tweets", new { Message = ManageMessageId.Error });
            }

            var newTweet = new Tweet
            {
                Content = model.Content,
                PageUrl = string.Empty,
                Date = DateTime.Now,
                AuthorId = user.Id
            };

            this.Data.Tweets.Add(newTweet);
            this.Data.SaveChanges();

            var viewModel = this.Data.Tweets.GetAll()
                                .Where(t => t.Id == newTweet.Id)
                                .Select(TweetViewModel.Create())
                                .FirstOrDefault();

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
            hubContext.Clients.All.viewTweet(viewModel);
            return this.Content("Tweet posted!");

            //return this.RedirectToAction("Index", "Tweets", new { Message = ManageMessageId.PostTweetSucess });
        }

        [System.Web.Mvc.Authorize]
        public ActionResult FavorTweet(int tweetId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var user = this.Data.Users.GetAll().FirstOrDefault(u => u.Id == currentUserId);
            var tweet = this.Data.Tweets.GetAll().FirstOrDefault(t => t.Id == tweetId);

            if (tweet == null && user == null)
            {
                return this.Redirect("/" + user.UserName);
            }

            tweet.FavoritedBy.Add(user);

            var notification = new Notification()
            {
                Content = string.Format("Your tweet was favoured by {0}", user.UserName),
                Date = DateTime.Now,
                ReceiverId = tweet.AuthorId,
                NotificationType = NotificationType.FavouriteTweet
            };

            this.Data.Notifications.Add(notification);

            this.Data.SaveChanges();

            return this.Redirect("/" + user.UserName);
        }

        [System.Web.Mvc.Authorize]
        public ActionResult ReTweet(int tweetId)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.GetAll().FirstOrDefault(u => u.Id == userId);
            var tweet = this.Data.Tweets.GetAll().FirstOrDefault(t => t.Id == tweetId);

            if (user == null && tweet == null)
            {
                return this.Redirect("/" + user.UserName);
            }

            tweet.RetweetedBy.Add(user);

            var notification = new Notification()
            {
                Content = string.Format("Your tweet was retweeted by {0}", user.UserName),
                Date = DateTime.Now,
                ReceiverId = tweet.AuthorId,
                NotificationType = NotificationType.Retweet
            };

            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();

            return this.Redirect("/" + user.UserName);
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Report(int tweetId)
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.Data.Users.GetAll().FirstOrDefault(u => u.Id == userId);
            var tweet = this.Data.Tweets.GetAll().FirstOrDefault(t => t.Id == tweetId);

            if (user == null && tweet == null)
            {
                return this.Redirect("/" + user.UserName);
            }

            var report = new Report()
            {
                Author = user,
                Tweet = tweet,
                Date = DateTime.Now,
                Content = "Report by " + user.UserName
            };

            tweet.Reports.Add(report);
            this.Data.SaveChanges();

            return this.Redirect("/" + user.UserName);
        }

        #region

        public enum ManageMessageId
        {
            PostTweetSucess,

            Error
        }

        #endregion
    }
}