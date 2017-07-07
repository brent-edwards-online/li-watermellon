namespace Watermellons.Repository
{
    /// <summary>
    /// The Unit Of Work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The roll back.
        /// </summary>
        void RollBack();

        /// <summary>
        /// The commit.
        /// </summary>
        void SaveChanges();
    }
}