namespace Watermellons.Repository
{
    using System;
    /// <summary>
    /// The database factory.
    /// </summary>
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        /// <summary>
        /// The data context.
        /// </summary>
        private WatermellonDbContext dataContext;

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>The <see cref="FitCloudCommissionsContext"/>.</returns>
        public WatermellonDbContext Get()
        {
            return this.dataContext ?? (this.dataContext = new WatermellonDbContext());
        }

        /// <summary>
        /// The dispose core.
        /// </summary>
        protected override void DisposeCore()
        {
            if (this.dataContext != null)
            {
                this.dataContext.Dispose();
            }
        }
    }
}
