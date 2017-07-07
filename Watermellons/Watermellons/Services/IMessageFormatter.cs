using Watermellons.EntityFramework;

namespace Watermellons.Services
{
    public interface IMessageFormatter
    {
        string FormatMessage(CompetitionEntry entry);
    }
}
