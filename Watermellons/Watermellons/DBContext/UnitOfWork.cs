namespace Watermellons.Repository
{
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// The unit of work.
    /// </summary>
    public class UnitOfWork : BaseFactory, IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        public UnitOfWork(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        /// <summary>
        /// The roll back.
        /// </summary>
        public void RollBack()
        {
            var changedEntries = this.DataContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Modified))
            {
                entry.CurrentValues.SetValues(entry.OriginalValues);
                entry.State = EntityState.Unchanged;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Added))
            {
                entry.State = EntityState.Detached;
            }

            foreach (var entry in changedEntries.Where(x => x.State == EntityState.Deleted))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void SaveChanges()
        {
            this.DataContext.SaveChanges();
        }
    }
}
