namespace IssueTracker.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Contracts;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
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
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            int questionMark = url.IndexOf('?');
            if (questionMark != -1)
            {
                IEnumerable<string[]> pairs =
                    url.Substring(questionMark + 1)
                        .Split('&')
                        .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());

                foreach (string[] pair in pairs)
                {
                    parameters.Add(pair[0], pair[1]);
                }
            }

            return parameters;
        }
    }
}