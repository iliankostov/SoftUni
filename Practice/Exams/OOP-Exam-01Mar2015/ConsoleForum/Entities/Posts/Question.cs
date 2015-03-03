namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    class Question : Post, IQuestion
    {
        public Question(string title, int id, IUser author, string body)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title
        {
            get;
            set;
        }

        public IList<IAnswer> Answers
        {
            get;
            private set;
        }

        public Answer BestAnswer
        {
            get;
            set;
        }

        public override string ToString()
        {
            StringBuilder questionString = new StringBuilder();
            questionString.AppendFormat("[ Question ID: {0} ]", this.Id).AppendLine()
                .AppendFormat("Posted by: {0}", this.Author.Username).AppendLine()
                .AppendFormat("Question Title: {0}", this.Title).AppendLine()
                .AppendFormat("Question Body: {0}", this.Body).AppendLine()
                .Append(new string('=', 20)).AppendLine();

            if (Answers.Any())
            {
                questionString.Append("Answers:").AppendLine()
                    .Append(PrintAnswers(this.Answers));
            }
            else
            {
                questionString.Append("No answers");
            }

            return questionString.ToString();
        }

        private string PrintAnswers(IList<IAnswer> answers)
        {

            StringBuilder answersString = new StringBuilder();

            // grab best answer
            var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);
            if (bestAnswer != null)
            {
                answersString.AppendLine(bestAnswer.ToString());
                var otherAnswer = this.Answers.Where(a => a.Id != bestAnswer.Id);
            }
            // must be ordered by ID
            
            for (int i = 0; i < answers.Count; i++)
            {
                answersString.Append(answers[i]);
                if (i < answers.Count - 1)
                {
                    answersString.AppendLine();
                }
            }
            return answersString.ToString();
        }
    }
}