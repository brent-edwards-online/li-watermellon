namespace Watermellons.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>The generic repository.</summary>
    /// <typeparam name="T">The data object type.</typeparam>
    public class GenericRepository<T> : BaseFactory, IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The data set.
        /// </summary>
        protected readonly IDbSet<T> DataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="factory">The database factory.</param>
        public GenericRepository(
            IDatabaseFactory factory)
            : base(factory)
        {
            this.DataSet = this.DataContext.Set<T>();
        }

        /// <summary>The get all.</summary>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return this.DataSet;
        }

        /// <summary>The get by id.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="T"/> entity or null.</returns>
        public virtual T GetById(object id)
        {
            return this.DataSet.Find(id);
        }

        /// <summary>
        /// Inserts the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            var entityEntry = this.DataContext.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DataSet.Add(entity);
            }
        }

        /// <summary>The delete.</summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(object id)
        {
            T entityToDelete = this.DataSet.Find(id);
            this.Delete(entityToDelete);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(T entityToUpdate)
        {
            var entityEntry = this.DataContext.Entry(entityToUpdate);
            if (entityEntry.State == EntityState.Detached)
            {
                this.DataSet.Attach(entityToUpdate);
            }

            entityEntry.State = EntityState.Modified;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(T entity)
        {
            var entityEntry = this.DataContext.Entry(entity);
            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DataSet.Attach(entity);
                this.DataSet.Remove(entity);
            }
        }
    }
}
