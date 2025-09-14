using Microsoft.EntityFrameworkCore;
using TalentDataTracker.Infrastructure.Persistence;

namespace TalentDataTracker.API.Extensions
{
    public static class WebAppExtensions
    {
        public static WebApplication RunMigrations(this WebApplication app, bool alwayRun = false)
        {
            if (app.Environment.IsDevelopment() || alwayRun)
            {
                using var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            return app;
        }
    }
}
