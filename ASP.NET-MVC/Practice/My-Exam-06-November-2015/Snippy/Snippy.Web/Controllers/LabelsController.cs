namespace Snippy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Ninject.Infrastructure.Language;

    using Snippy.Web.Models.ViewModels;

    public class LabelsController : BaseController
    {
        public ActionResult Details(int id)
        {
            var label = this.Data.Labels.GetAll()
                            .Where(l => l.Id == id)
                            .ProjectTo<LabelViewModel>()
                            .FirstOrDefault();

            if (label == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            var snippets = this.Data.Snippets.GetAll()
                               .Where(s => s.Labels.Any(l => l.Id == id))
                               .ProjectTo<SnippetViewModel>()
                               .ToEnumerable();

            this.ViewBag.LabelText = label.Text;
            return this.View(snippets);
        }
    }
}