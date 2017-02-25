namespace Snippy.Data.Contracts
{
    using Snippy.Models;

    public interface ISnippyData
    {
        IRepository<User> Users { get; }

        IRepository<Snippet> Snippets { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Language> Languages { get; }

        IRepository<Label> Labels { get; }

        void SaveChanges();
    }
}