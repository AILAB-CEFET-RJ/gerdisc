using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Mapper;

namespace gerdisc.Services.ExternalResearcher
{
    public class ExternalResearcherService : IExternalResearcherService
    {
        private readonly IRepository _repository;
        private readonly ILogger<ExternalResearcherService> _logger;

        public ExternalResearcherService(
            IRepository repository,
            ILogger<ExternalResearcherService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ExternalResearcherDto> CreateExternalResearcherAsync(ExternalResearcherDto externalResearcherDto)
        {
            var externalResearcher = externalResearcherDto.ToEntity();
            var userId = (await _repository.User.AddAsync(externalResearcher.User)).Id;
            externalResearcher.UserId = userId;
            await _repository.ExternalResearcher.AddAsync(externalResearcher);

            _logger.LogInformation($"ExternalResearcher {externalResearcher.User.Id} created successfully.");
            return externalResearcherDto;
        }

        public async Task<ExternalResearcherDto> GetExternalResearcherAsync(Guid id)
        {
            var externalResearcherEntity = await _repository.ExternalResearcher.GetByIdAsync(id, x => x.User);
            if (externalResearcherEntity == null)
            {
                throw new ArgumentException("ExternalResearcher not found.");
            }

            return externalResearcherEntity.ToDto();
        }

        public async Task<IEnumerable<ExternalResearcherDto>> GetAllExternalResearchersAsync()
        {
            var externalResearchers = await _repository.ExternalResearcher.GetAllAsync(x => x.User);
            var externalResearcherDtos = new List<ExternalResearcherDto>();
            foreach (var externalResearcher in externalResearchers)
            {
                externalResearcherDtos.Add(externalResearcher.ToDto());
            }

            return externalResearcherDtos;
        }

        public async Task<ExternalResearcherDto> UpdateExternalResearcherAsync(Guid id, ExternalResearcherDto externalResearcherDto)
        {
            var existingExternalResearcher = await _repository.ExternalResearcher.GetByIdAsync(id);
            if (existingExternalResearcher == null)
            {
                throw new ArgumentException($"ExternalResearcher with id {id} does not exist.");
            }

            existingExternalResearcher = externalResearcherDto.ToEntity(existingExternalResearcher);


            return existingExternalResearcher.ToDto();
        }

        public async Task DeleteExternalResearcherAsync(Guid id)
        {
            var existingExternalResearcher = await _repository.ExternalResearcher.GetByIdAsync(id);
            if (existingExternalResearcher == null)
            {
                throw new ArgumentException($"ExternalResearcher with id {id} does not exist.");
            }

            await _repository.ExternalResearcher.DeactiveAsync(existingExternalResearcher);
        }
    }
}
