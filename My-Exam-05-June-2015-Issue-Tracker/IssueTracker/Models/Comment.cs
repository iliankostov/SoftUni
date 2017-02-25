namespace IssueTracker.Models
{
    using System;
    using System.Text;
    using Utilities;

    public class Comment
    {
        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Constants.CommentTextMinLenght)
                {
                    string message = string.Format(Messages.TextLenghtExeptionMessage, Constants.CommentTextMinLenght);
                    throw new ArgumentException(message);
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            return
                new StringBuilder()
                    .AppendLine(this.Text)
                    .AppendFormat("-- {0}", this.Author.Username)
                    .AppendLine()
                    .ToString()
                    .Trim();
        }
    }
}