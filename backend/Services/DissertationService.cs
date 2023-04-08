using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gerdisc.Services.Dissertation
{
    public class DissertationService : IDissertationService
    {
        private readonly IRepository _repository;
        private readonly ILogger<DissertationService> _logger;

        public DissertationService(
            IRepository repository,
            ILogger<DissertationService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DissertationDto> CreateDissertationAsync(DissertationDto dissertationDto)
        {
            var count = await _repository.Dissertation.CountAsync();
            dissertationDto.Id = count + 1;

            var dissertation = dissertationDto.ToEntity();

            await _repository.Dissertation.AddAsync(dissertation);
            await _repository.Dissertation.CommitAsync();

            _logger.LogInformation($"Dissertation {dissertation.Name} created successfully.");
            return dissertationDto;
        }

        public async Task<DissertationDto> GetDissertationAsync(int id)
        {
            var dissertationEntity = await _repository.Dissertation.GetSingleAsync(id);
            if (dissertationEntity == null)
            {
                throw new ArgumentException("Dissertation not found.");
            }

            return dissertationEntity.ToDto();
        }

        public async Task<IEnumerable<DissertationDto>> GetAllDissertationsAsync()
        {
            var dissertations = await _repository.Dissertation.GetAllAsync();
            var dissertationDtos = new List<DissertationDto>();
            foreach (var dissertation in dissertations)
            {
                dissertationDtos.Add(dissertation.ToDto());
            }

            return dissertationDtos;
        }

        public async Task<DissertationDto> UpdateDissertationAsync(int id, DissertationDto dissertationDto)
        {
            var existingDissertation = await _repository.Dissertation.GetSingleAsync(id);
            if (existingDissertation == null)
            {
                throw new ArgumentException($"Dissertation with id {id} does not exist.");
            }

            existingDissertation = dissertationDto.ToEntity(existingDissertation);

            await _repository.Dissertation.CommitAsync();

            return existingDissertation.ToDto();
        }

        public async Task DeleteDissertationAsync(int id)
        {
            var existingDissertation = await _repository.Dissertation.GetSingleAsync(id);
            if (existingDissertation == null)
            {
                throw new ArgumentException($"Dissertation with id {id} does not exist.");
            }

            _repository.Dissertation.Delete(existingDissertation);
            await _repository.Dissertation.CommitAsync();
        }
    }
}
