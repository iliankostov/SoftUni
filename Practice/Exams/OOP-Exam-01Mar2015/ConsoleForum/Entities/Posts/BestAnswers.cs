namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            string asterisk = new string('*', 20);
            StringBuilder answerString = new StringBuilder();
            answerString.AppendLine(asterisk);
            answerString.AppendLine(base.ToString());
            answerString.Append(asterisk);

            return answerString.ToString();
        }
    }
}