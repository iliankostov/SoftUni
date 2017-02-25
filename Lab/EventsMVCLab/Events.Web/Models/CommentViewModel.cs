namespace Events.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using Events.Data;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel()
        {
            return c => new CommentViewModel()
                {
                    Id = c.Id,
                    Text = c.Text,
                    EventId = c.Event.Id,
                    Author = c.Author.FullName,
                };
        }
    }
}