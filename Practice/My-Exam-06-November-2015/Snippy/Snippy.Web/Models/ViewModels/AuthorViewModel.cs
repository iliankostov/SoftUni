namespace Snippy.Web.Models.ViewModels
{
    using Snippy.Models;
    using Snippy.Web.Contracts;

    public class AuthorViewModel : IMapFrom<User>
    {
        public string AuthorId { get; set; }

        public string UserName { get; set; }
    }
}