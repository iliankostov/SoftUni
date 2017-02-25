namespace Snippy.Web.Models.ViewModels
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<SnippetViewModel> LatestSnippets { get; set; }

        public IEnumerable<CommentViewModel> LatestComments { get; set; }

        public IEnumerable<LabelViewModel> BestLabels { get; set; }
    }
}