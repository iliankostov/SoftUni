namespace Events.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Events.Data;
    using Events.Web.Extensions;
    using Events.Web.Models;

    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseController
    {
        [HttpGet]
        public ActionResult Create(int id)
        {
            var model = new CommentViewModel();
            model.EventId = id;
            return this.PartialView("_CommentForm", model);
        }

        [HttpPost]
        public ActionResult Create(ComentBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                this.AddNotification("Invalid input data", NotificationType.ERROR);
                return this.RedirectToAction("Index", "Home");
            }

            var userId = this.User.Identity.GetUserId();
            var eventById = this.db.Events.Find(model.EventId);

            var comment = new Comment
                {
                    AuthorId = userId,
                    Text = model.Text,
                    Date = DateTime.Now,
                    Event = eventById
                };

            this.db.Comments.Add(comment);
            this.db.SaveChanges();

            var commentView = this.db.Comments
                                  .Where(c => c.Id == comment.Id)
                                  .Select(CommentViewModel.ViewModel())
                                  .FirstOrDefault();

            return this.PartialView("_CommentRow", commentView);
        }

        [HttpGet]
        public ActionResult ConfirmDelete(int commentId)
        {
            var comment = this.db.Comments
                              .Where(c => c.Id == commentId)
                              .Select(CommentViewModel.ViewModel())
                              .FirstOrDefault();

            return this.PartialView("_ConfirmDeleteComment", comment);
        }
    }
}