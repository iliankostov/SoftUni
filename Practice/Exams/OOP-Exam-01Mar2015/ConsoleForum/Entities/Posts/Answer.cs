namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Answer ID: {0} ]", this.Id))
                .AppendLine(string.Format("Posted by: {0}", this.Author.Username))
                .AppendLine(string.Format("Answer Body: {0}", this.Body))
                .Append(Utility.Constants.AnswerDelimeter);

            return output.ToString();
        }
    }
}
