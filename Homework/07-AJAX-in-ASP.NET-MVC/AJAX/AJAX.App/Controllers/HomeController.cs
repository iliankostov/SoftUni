namespace AJAX.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AJAX.App.Models;
    using AJAX.Data;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users()
        {
            this.ViewBag.Message = "Users";

            var users = this.Data.Users.GetAll()
                .Select(UserViewModel.Create())
                .ToList();

            return this.View(users);
        }

        [HttpGet]
        public ActionResult Towns()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Search(string term)
        {
            var items = this.Data.Towns.GetAll()
                .Where(t => t.Name.Contains(term))
                .Select(t => t.Name)
                .ToList();

            return this.Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}