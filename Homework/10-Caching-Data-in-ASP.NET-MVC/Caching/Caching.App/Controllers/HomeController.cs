namespace Caching.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Caching.App.Infrastructure;
    using Caching.App.Models;
    using Caching.Data.UnitOfWork;

    using PagedList;

    public class HomeController : BaseController
    {
        public HomeController(IApplicationData data)
            : base(data)
        {
        }

        [OutputCache(Duration = 15)]
        public ActionResult Index()
        {
            return this.View();
        }

        [OutputCache(Duration = 300)]
        public ActionResult RssFeed(int? page)
        {
            var document = XDocument.Load("https://softuni.bg/feed/news");
            var news = new HashSet<SoftUniNewsModel>();

            foreach (var childElem in document.XPathSelectElements("//item"))
            {
                var link = childElem.Element("link").Value;
                var title = childElem.Element("title").Value;
                var createdNews = new SoftUniNewsModel
                    {
                        Link = link,
                        Title = title
                    };
                news.Add(createdNews);
            }

            return this.PartialView(
                "_RssFeed",
                news.OrderBy(n => n.Title).ToPagedList(pageNumber: page ?? 1, pageSize: AppConfig.PageSize));
        }
    }
}