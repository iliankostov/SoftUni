namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleForum.Contracts;

    public class Question : Post, IQuestion
    {
        public Question(int id, string body, IUser author, string title)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
            this.HasBestAnswer = false;
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; private set; }

        public bool HasBestAnswer { get; set; }

        public void AddAnswer(IAnswer answer)
        {
            this.Answers.Add(answer);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Question ID: {0} ]", this.Id))
                .AppendLine(string.Format("Posted by: {0}", this.Author.Username))
                .AppendLine(string.Format("Question Title: {0}", this.Title))
                .AppendLine(string.Format("Question Body: {0}", this.Body))
                .AppendLine(Utility.Constants.QuestionDelimeter);

            if (!this.Answers.Any())
            {
                output.Append("No answers");
            }
            else
            {
                output.AppendLine("Answers:");
                var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);
                if (bestAnswer != null)
                {
                    output.AppendLine(bestAnswer.ToString());
                    var otherAnswers = this.Answers.Where(a => a.Id != bestAnswer.Id);
                    output.Append(string.Join(Environment.NewLine, otherAnswers));
                }
                else
                {
                    output.Append(string.Join(Environment.NewLine, this.Answers));                    
                }
            }

            return output.ToString();
        }
    }
}
