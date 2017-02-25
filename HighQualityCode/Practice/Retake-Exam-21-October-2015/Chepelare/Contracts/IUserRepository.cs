namespace Chepelare.Contracts
{
    using Chepelare.Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}