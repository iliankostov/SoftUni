namespace Snippy.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Ninject.Infrastructure.Language;

    using Snippy.Web.Models.ViewModels;

    public class LanguagesController : BaseController
    {
        public ActionResult Details(int id)
        {
            var language = this.Data.Languages.GetAll()
                               .Where(l => l.Id == id)
                               .ProjectTo<LanguageViewModel>()
                               .FirstOrDefault();

            if (language == null)
            {
                this.RedirectToAction("Index", "Home");
            }

            var snippets = this.Data.Snippets.GetAll()
                               .Where(s => s.Language.Id == id)
                               .ProjectTo<SnippetViewModel>()
                               .ToEnumerable();

            this.ViewBag.LanguageName = language.Name;

            return this.View(snippets);
        }
    }
}