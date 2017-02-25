namespace Snippy.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Snippy.Models;
    using Snippy.Web.Extensions;
    using Snippy.Web.Models.BindingModels;
    using Snippy.Web.Models.ViewModels;

    [Authorize]
    public class CommentsController : BaseController
    {
        [HttpGet]
        public ActionResult Create(int id)
        {
            var model = new CommentViewModel();
            model.SnippetId = id;
            return this.PartialView("_CommentForm", model);
        }

        [HttpPost]
        public ActionResult Create(CommentBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.AddNotification("Invalid input data", NotificationType.ERROR);
                return this.RedirectToAction("Details", "Snippets");
            }

            var userId = this.User.Identity.GetUserId();

            var comment = new Comment
                {
                    AuthorId = userId,
                    Content = model.Content,
                    CreatedOn = DateTime.Now,
                    SnippetId = model.SnippetId
                };

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            var commentView = this.Data.Comments.GetAll()
                                  .Where(c => c.Id == comment.Id)
                                  .ProjectTo<CommentViewModel>()
                                  .FirstOrDefault();

            this.AddNotification("Your Comment was accepted", NotificationType.SUCCESS);
            return this.PartialView("_CommentRow", commentView);
        }
    }
}