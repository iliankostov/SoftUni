namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Twitter.App.Models.ViewModels;
    using Twitter.Data.Contracts;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            var user =
                this.Data.Users.GetAll()
                    .Where(u => u.UserName == username)
                    .Select(UserViewModel.Create())
                    .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Index");
            }
            return this.View(user);
        }

        public ActionResult Favourite(string username)
        {
            var user =
                this.Data.Users.GetAll()
                    .Where(u => u.UserName == username)
                    .Select(UserViewModel.Create())
                    .FirstOrDefault();

            if (user == null)
            {
                return this.RedirectToAction("Favourite");
            }
            return this.View(user);
        }
    }
}