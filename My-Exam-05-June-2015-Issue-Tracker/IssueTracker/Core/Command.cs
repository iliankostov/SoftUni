namespace IssueTracker.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using IssueTracker.Contracts;

    public class Command : ICommand
    {
        // todo refactor constructor
        public Command(string url)
        {
            this.Parameters = this.ExtractParameters(url);
            this.Action = this.ExtractAction(url);
        }

        public string Action { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private string ExtractAction(string url)
        {
            int questionMark = url.IndexOf('?');
            return questionMark != -1 ? url.Substring(0, questionMark) : url;
        }

        private IDictionary<string, string> ExtractParameters(string url)
        {
            var parameters = new Dictionary<string, string>();
            int questionMark = url.IndexOf('?');
            if (questionMark != -1)
            {
                var pairs =
                    url.Substring(questionMark + 1)
                        .Split('&')
                        .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());

                foreach (var pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }
            }

            return parameters;
        }
    }
}