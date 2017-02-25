namespace Snippy.Web.Models.ViewModels
{
    using AutoMapper;

    using Snippy.Models;
    using Snippy.Web.Contracts;

    public class LabelViewModel : IMapFrom<Label>, ICustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SnippetsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Label, LabelViewModel>()
                         .ForMember(s => s.SnippetsCount, opt => opt.MapFrom(s => s.Snippets.Count));
        }
    }
}