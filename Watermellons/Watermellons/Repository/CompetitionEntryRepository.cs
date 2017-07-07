using System;

namespace Watermellons.Repository
{
    using EntityFramework;
    using System.Collections.Generic;
    using System.Linq;

    public class CompetitionEntryRepository : GenericRepository<CompetitionEntry>, ICompetitionEntryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetitionEntryRepository"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public CompetitionEntryRepository(IDatabaseFactory factory)
            : base(factory)
        {
        }

    }
}
