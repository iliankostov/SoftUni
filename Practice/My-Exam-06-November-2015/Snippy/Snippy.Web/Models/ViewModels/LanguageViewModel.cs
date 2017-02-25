namespace Snippy.Web.Models.ViewModels
{
    using Snippy.Models;
    using Snippy.Web.Contracts;

    public class LanguageViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}