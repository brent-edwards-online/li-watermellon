namespace Watermellons.Repository
{
    using EntityFramework;
    using System.Data.Entity;
    using System.Diagnostics;

    /// <summary>
    /// The fit cloud commissions context.
    /// </summary>
    public partial class WatermellonDbContext : DbContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="FitCloudCommissionsContext"/> class.
        /// </summary>
        static WatermellonDbContext()
        {
            Database.SetInitializer<WatermellonDbContext>(null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FitCloudCommissionsContext"/> class.
        /// Base name refers to the web.config connection string key.  Which remains the same for all fitcloud internal components.
        /// </summary>
        public WatermellonDbContext()
            : base("Name=WatermellonConnectionString")
        {
            this.Database.CommandTimeout = 180;
            this.Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<CompetitionEntry> CompetitionEntry { get; set; }
        

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new Account_UncommissionableMap());
        }
    }
}
