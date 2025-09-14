using TalentDataTracker.Application.Commands.SampleEntity;
using TalentDataTracker.Domain.Entities;

namespace TalentDataTracker.Application.Mappers
{
    public static class SampleCommandsMapper
    {
        public static Sample ToEntity(CreateSampleCommand command)
        {
            return new Sample
            {
                Name = command.Name,
                Date = command.Date
            };
        }
    }
}
