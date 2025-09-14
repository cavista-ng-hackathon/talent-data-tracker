using Microsoft.EntityFrameworkCore;
using TalentDataTracker.Domain.Entities;

namespace TalentDataTracker.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sample> Samples { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}