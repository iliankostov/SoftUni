namespace News.Repositories.Interfaces
{
    using News.Models;

    public interface IUnitOfWorkData
    {
        IRepository<NewsItem> News { get; }

        void SaveChanges();
    }
}