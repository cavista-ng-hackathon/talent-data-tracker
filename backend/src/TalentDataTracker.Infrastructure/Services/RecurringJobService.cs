using Hangfire.Console;
using Hangfire.Server;
using TalentDataTracker.Application.Interfaces;

namespace TalentDataTracker.Infrastructure.Services
{
    public class RecurringJobService : IRecurringJobService
    {
        public async Task PollSmartRecruiterApiForUpdates(PerformContext context)
        {
            context.WriteLine("Smart Recruiters Polling started...");
            await Task.CompletedTask;
        }
    }
}