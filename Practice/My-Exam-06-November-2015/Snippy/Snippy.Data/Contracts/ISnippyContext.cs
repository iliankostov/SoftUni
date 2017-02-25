namespace Snippy.Data.Contracts
{
    using System.Data.Entity;

    using Snippy.Models;

    public interface ISnippyContext
    {
        IDbSet<Snippet> Snippets { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Language> Languages { get; }

        IDbSet<Label> Labels { get; }
    }
}