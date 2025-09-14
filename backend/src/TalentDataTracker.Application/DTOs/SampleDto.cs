using TalentDataTracker.Domain.Entities;

namespace TalentDataTracker.Application.DTOs
{
    public class SampleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public static SampleDto FromEntity(Sample entity)
        {
            return new SampleDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
