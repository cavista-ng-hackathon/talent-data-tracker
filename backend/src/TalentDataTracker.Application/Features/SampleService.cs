using TalentDataTracker.Application.Commands.SampleEntity;
using TalentDataTracker.Application.DTOs;
using TalentDataTracker.Application.Exceptions;
using TalentDataTracker.Application.Interfaces;
using TalentDataTracker.Application.Mappers;
using TalentDataTracker.Application.Validations.Sample;
using TalentDataTracker.Domain.Interfaces;

namespace TalentDataTracker.Application.Features
{
    public sealed class SampleService : ISampleService
    {
        private readonly IRepositoryManager _repository;

        public SampleService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task<SampleDto> AddSample(CreateSampleCommand command)
        {
            var validator = new CreateSampleValidator().Validate(command);
            if (!validator.IsValid)
            {
                throw new BadRequestException(validator.Errors.FirstOrDefault()?.ErrorMessage ?? "Invalid request");
            }

            var sample = SampleCommandsMapper.ToEntity(command);
            await _repository.Sample.AddAsync(sample);

            await _repository.SaveAsync();
            return SampleDto.FromEntity(sample);
        }
    }
}