namespace News.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using News.Models;
    using News.Repositories.Interfaces;
    using News.Services.Models;

    public class NewsController : BaseController
    {
        public NewsController()
        {
        }

        public NewsController(IUnitOfWorkData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetNews()
        {
            var newsView = this.Data.News.GetAll()
                .OrderByDescending(n => n.PublishDate)
                .Select(NewsViewModel.Create());

            return this.Ok(newsView);
        }

        [HttpPost]
        public IHttpActionResult PostNewsItem(NewsBindingModel newsBindingModel)
        {
            if (newsBindingModel == null)
            {
                return this.BadRequest("News data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newNews = new NewsItem
                {
                    Title = newsBindingModel.Title, 
                    Content = newsBindingModel.Content, 
                    PublishDate = newsBindingModel.PublishDate
                };

            this.Data.News.Add(newNews);
            this.Data.SaveChanges();

            var newsView = this.Data.News.GetAll()
                .Where(n => n.Id == newNews.Id)
                .Select(NewsViewModel.Create())
                .FirstOrDefault();

            var uriLocation = new
                {
                    controller = "news",
                    id = newNews.Id
                };

            return this.CreatedAtRoute("DefaultApi", uriLocation, newsView);
        }

        [HttpPut]
        public IHttpActionResult EditNewsById(int id, NewsBindingModel newsBindingModel)
        {
            var news = this.Data.News.GetAll().FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return this.NotFound();
            }

            if (newsBindingModel == null)
            {
                return this.BadRequest("News data is missing");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            news.Title = newsBindingModel.Title;
            news.Content = newsBindingModel.Content;
            news.PublishDate = newsBindingModel.PublishDate;

            this.Data.SaveChanges();

            var newsView = this.Data.News.GetAll()
                .Where(n => n.Id == news.Id)
                .Select(NewsViewModel.Create())
                .FirstOrDefault();

            return this.Ok(newsView);
        }

        [HttpDelete]
        public IHttpActionResult DeleteNewsById(int id)
        {
            var news = this.Data.News.GetAll().FirstOrDefault(n => n.Id == id);
            if (news == null)
            {
                return this.NotFound();
            }

            this.Data.News.Delete(news);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}