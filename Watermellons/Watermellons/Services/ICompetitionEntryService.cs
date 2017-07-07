namespace Watermellons.Services
{
    using EntityFramework;
    using System.Collections.Generic;
    public interface ICompetitionEntryService
    {
        bool EntryAlreadyExists(string email);
        bool InsertCompetitionEntry(CompetitionEntry entry, out string errorMessage);
    }
}