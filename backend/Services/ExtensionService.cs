using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gerdisc.Services.Extension
{
    public class ExtensionService : IExtensionService
    {
        private readonly IRepository _repository;
        private readonly ILogger<ExtensionService> _logger;

        public ExtensionService(
            IRepository repository,
            ILogger<ExtensionService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ExtensionDto> CreateExtensionAsync(ExtensionDto extensionDto)
        {
            var extension = extensionDto.ToEntity();

            await _repository.Extension.AddAsync(extension);

            _logger.LogInformation($"Extension {extension.StudentId} created successfully.");
            return extensionDto;
        }

        public async Task<ExtensionDto> GetExtensionAsync(Guid id)
        {
            var extensionEntity = await _repository.Extension.GetByIdAsync(id);
            if (extensionEntity == null)
            {
                throw new ArgumentException("Extension not found.");
            }

            return extensionEntity.ToDto();
        }

        public async Task<IEnumerable<ExtensionDto>> GetAllExtensionsAsync()
        {
            var extensions = await _repository.Extension.GetAllAsync();
            var extensionDtos = new List<ExtensionDto>();
            foreach (var extension in extensions)
            {
                extensionDtos.Add(extension.ToDto());
            }

            return extensionDtos;
        }

        public async Task<ExtensionDto> UpdateExtensionAsync(Guid id, ExtensionDto extensionDto)
        {
            var existingExtension = await _repository.Extension.GetByIdAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            existingExtension = extensionDto.ToEntity(existingExtension);


            return existingExtension.ToDto();
        }

        public async Task DeleteExtensionAsync(Guid id)
        {
            var existingExtension = await _repository.Extension.GetByIdAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            await _repository.Extension.DeleteAsync(existingExtension);
        }
    }
}
