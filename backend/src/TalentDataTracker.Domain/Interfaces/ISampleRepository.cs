using TalentDataTracker.Domain.Entities;

namespace TalentDataTracker.Domain.Interfaces
{
    public interface ISampleRepository
    {
        Task AddAsync(Sample sample);
    }
}
