namespace Chepelare.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface contracting all repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get All objects from repository
        /// </summary>
        /// <returns>Collections of objects</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get specific object from repository by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object by id</returns>
        T Get(int id);

        /// <summary>
        /// Add object into repository
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Update specific object by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newItem"></param>
        /// <returns>True if object was updated and false if update fails</returns>
        bool Update(int id, T newItem);

        /// <summary>
        /// Delete specific object by id
        /// </summary>
        /// <param name="id">True if object was deleted and false if delete fails</param>
        /// <returns></returns>
        bool Delete(int id);
    }
}