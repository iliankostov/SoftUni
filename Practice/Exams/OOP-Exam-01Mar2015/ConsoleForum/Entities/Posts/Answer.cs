namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder answerString = new StringBuilder();
            answerString.AppendFormat("[ Answer ID: {0} ]", this.Id).AppendLine()
                .AppendFormat("Posted by: {0}", this.Author.Username).AppendLine()
                .AppendFormat("Answer Body: {0}", this.Body).AppendLine()
                .Append(new string('-', 20));

            return answerString.ToString();
        }
    }
}