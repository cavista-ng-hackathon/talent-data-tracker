using TalentDataTracker.Application.Interfaces;
using TalentDataTracker.Domain.Interfaces;

namespace TalentDataTracker.Application.Features
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISampleService> _sampleService;

        public ServiceManager(IRepositoryManager repository)
        {
            _sampleService = new Lazy<ISampleService>(() 
                => new SampleService(repository));
        }

        public ISampleService Sample => _sampleService.Value;
    }
}
