namespace Twitter.App.Controllers
{
    using System.Web.Mvc;

    using Twitter.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}