using Hangfire.RecurringJobExtensions;
using Hangfire.Server;

namespace TalentDataTracker.Application.Interfaces
{
    public interface IRecurringJobService
    {
        [RecurringJob("0 0 * * FRI", TimeZone = "UTC")]
        Task PollSmartRecruiterApiForUpdates(PerformContext context);
    }
}