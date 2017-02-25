namespace Snippy.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Snippy.Models;
    using Snippy.Web.Contracts;

    public class SnippetViewModel : IMapFrom<Snippet>, ICustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorUserName { get; set; }

        public IEnumerable<LabelViewModel> Lables { get; set; }

        public LanguageViewModel Language { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Snippet, SnippetViewModel>()
                         .ForMember(s => s.AuthorUserName, opt => opt.MapFrom(s => s.Author.UserName))
                         .ForMember(s => s.Lables, opt => opt.MapFrom(s => s.Labels))
                         .ForMember(s => s.Language, opt => opt.MapFrom(s => s.Language))
                         .ForMember(
                             s => s.Comments,
                             opt => opt.MapFrom(s => s.Comments.OrderByDescending(c => c.CreatedOn)));
        }
    }
}