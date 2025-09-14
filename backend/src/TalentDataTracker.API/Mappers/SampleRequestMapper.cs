using TalentDataTracker.API.Requests;
using TalentDataTracker.Application.Commands.SampleEntity;

namespace TalentDataTracker.API.Mappers
{
    public static class SampleRequestMapper
    {
        public static CreateSampleCommand ToSampleCommand(CreateSampleRequest request)
        {
            return new CreateSampleCommand
            {
                Name = request.Name,
                Date = request.DueDate
            };
        }
    }
}
