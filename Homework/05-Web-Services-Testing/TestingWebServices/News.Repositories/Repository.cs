namespace News.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using News.Repositories.Interfaces;

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private DbContext context;

        private IDbSet<T> set;

        public Repository()
            : this(new NewsContext())
        {
        }

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public IQueryable<T> GetAll()
        {
            return this.set;
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}