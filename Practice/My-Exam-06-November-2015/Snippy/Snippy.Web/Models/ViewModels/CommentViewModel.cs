namespace Snippy.Web.Models.ViewModels
{
    using System;

    using AutoMapper;

    using Snippy.Models;
    using Snippy.Web.Contracts;

    public class CommentViewModel : IMapFrom<Comment>, ICustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AuthorUserName { get; set; }

        public int SnippetId { get; set; }

        public string SnippetTitle { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                         .ForMember(s => s.AuthorUserName, opt => opt.MapFrom(s => s.Author.UserName))
                         .ForMember(s => s.SnippetId, opt => opt.MapFrom(s => s.Snippet.Id))
                         .ForMember(s => s.SnippetTitle, opt => opt.MapFrom(s => s.Snippet.Title));
        }
    }
}