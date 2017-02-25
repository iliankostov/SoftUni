namespace ConsoleForum.Entities.Posts
{
    using System.Text;

    using ConsoleForum.Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(Utility.Constants.BestAnswerDelimeter)
                .AppendLine(base.ToString())
                .Append(Utility.Constants.BestAnswerDelimeter);
            return output.ToString();
        }
    }
}
