namespace AJAX.Data.Contracts
{
    using AJAX.Models;

    public interface IAjaxData
    {
        IRepository<User> Users { get; }

        IRepository<Town> Towns { get; }

        void SaveChanges();
    }
}