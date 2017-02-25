namespace Snippy.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Ninject.Infrastructure.Language;

    using Snippy.Models;
    using Snippy.Web.Extensions;
    using Snippy.Web.Models.BindingModels;
    using Snippy.Web.Models.ViewModels;

    public class SnippetsController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var snippets = this.Data.Snippets.GetAll()
                               .OrderByDescending(s => s.CreatedOn)
                               .ProjectTo<SnippetViewModel>()
                               .ToEnumerable();

            return this.View(snippets);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.GetAll()
                              .Where(s => s.Id == id)
                              .ProjectTo<SnippetViewModel>()
                              .FirstOrDefault();

            return this.View(snippet);
        }

        [Authorize]
        public ActionResult My()
        {
            var userId = this.User.Identity.GetUserId();

            var snippets = this.Data.Snippets.GetAll()
                               .Where(s => s.AuthorId == userId)
                               .ProjectTo<SnippetViewModel>()
                               .ToEnumerable();

            return this.View(snippets);
        }

        [Authorize]
        [HttpGet]
        public ActionResult New()
        {
            var userName = this.User.Identity.GetUserName();

            var newSnippet = new SnippetBindingModel()
                {
                    AuthorUserName = userName
                };

            return this.View(newSnippet);
        }

        [Authorize]
        [HttpPost]
        public ActionResult New(SnippetBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.View();
            }

            var userId = this.User.Identity.GetUserId();

            var snippet = new Snippet()
                {
                    AuthorId = userId,
                    Title = model.Title,
                    Description = model.Description,
                    Code = model.Code,
                    CreatedOn = DateTime.Now,
                };

            snippet.LanguageId = this.GetLanguage(model.Language).Id;
            var labels = this.GetLabels(model.Labels);

            foreach (var label in labels)
            {
                snippet.Labels.Add(label);
            }

            this.Data.Snippets.Add(snippet);
            this.Data.SaveChanges();

            this.AddNotification("New snippet created", NotificationType.SUCCESS);
            return this.RedirectToAction("My", "Snippets");
        }

        private IEnumerable<Label> GetLabels(string labelsStr)
        {
            var labels = labelsStr.Split(';');
            IList<Label> result = new List<Label>();

            foreach (var label in labels)
            {
                var pureLabel = label.Trim().ToLower();
                var newLabel = this.Data.Labels.GetAll().FirstOrDefault(l => l.Text == pureLabel);
                if (newLabel == null)
                {
                    newLabel = new Label() { Text = label };
                    this.Data.Labels.Add(newLabel);
                }

                result.Add(newLabel);
            }

            this.Data.SaveChanges();
            return result;
        }

        private Language GetLanguage(string languageStr)
        {
            var language = this.Data.Languages.GetAll().FirstOrDefault(l => l.Name == languageStr);

            if (language == null)
            {
                language = new Language() { Name = languageStr };
                this.Data.Languages.Add(language);
                this.Data.SaveChanges();
            }

            return language;
        }
    }
}