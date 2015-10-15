namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using PagedList;

    using Twitter.App.Constants;
    using Twitter.App.Models.ViewModels;
    using Twitter.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        // ALL TWEETS
        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var tweets = this.Data.Tweets.GetAll().OrderByDescending(t => t.Date).Select(TweetViewModel.Create());

            if (tweets.Any())
            {
                int pageSize = Constants.DefaultPageSize;
                int pageNumber = page ?? Constants.DefaultStartPage;

                return this.View(tweets.ToPagedList(pageNumber, pageSize));
            }

            return this.View();
        }
    }
}