using TalentDataTracker.Domain.Entities;
using TalentDataTracker.Domain.Interfaces;
using TalentDataTracker.Infrastructure.Persistence;

namespace TalentDataTracker.Infrastructure.Repositories
{
    public sealed class SampleRepository : Repository<Sample>, ISampleRepository
    {
        public SampleRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task AddAsync(Sample sample)
        {
            await InsertAsync(sample, false);
        }
    }
}
