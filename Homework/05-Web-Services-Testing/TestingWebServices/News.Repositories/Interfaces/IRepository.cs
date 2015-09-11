namespace News.Repositories.Interfaces
{
    using System.Linq;

    public interface IRepository<T>
        where T : class
    {
        T Find(int id);

        void Add(T entity);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}