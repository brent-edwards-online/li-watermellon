namespace Watermellons.Repository
{
    using System.Collections.Generic;

    /// <summary>
    /// The Generic Repository interface.
    /// </summary>
    /// <typeparam name="T">The Data Object.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>The get all.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="T"/>.</returns>
        T GetById(object id);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">The id.</param>
        void Delete(object id);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        void Delete(T entityToDelete);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        void Update(T entityToUpdate);
    }
}