namespace Snippy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Ninject.Infrastructure.Language;

    using Snippy.Web.Models.ViewModels;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var latestSnippets = this.Data.Snippets.GetAll()
                                     .OrderByDescending(s => s.CreatedOn)
                                     .ProjectTo<SnippetViewModel>()
                                     .Take(5)
                                     .ToEnumerable();

            var latestComments = this.Data.Comments.GetAll()
                                     .OrderByDescending(c => c.CreatedOn)
                                     .ProjectTo<CommentViewModel>()
                                     .Take(5)
                                     .ToEnumerable();

            var bestLabels = this.Data.Labels.GetAll()
                                 .OrderByDescending(l => l.Snippets.Count)
                                 .ProjectTo<LabelViewModel>()
                                 .Take(5)
                                 .ToEnumerable();

            var model = new HomePageViewModel()
                {
                    LatestSnippets = latestSnippets,
                    LatestComments = latestComments,
                    BestLabels = bestLabels
                };

            return this.View(model);
        }
    }
}