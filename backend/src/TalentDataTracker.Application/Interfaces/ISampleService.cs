using TalentDataTracker.Application.Commands.SampleEntity;
using TalentDataTracker.Application.DTOs;

namespace TalentDataTracker.Application.Interfaces
{
    public interface ISampleService
    {
        Task<SampleDto> AddSample(CreateSampleCommand command);
    }
}
