using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using gerdisc.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gerdisc.Services
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

        /// <inheritdoc />
        public async Task<ExtensionInfoDto> CreateExtensionAsync(ExtensionDto extensionDto)
        {
            var extension = extensionDto.ToEntity();

            extension = await _repository.Extension.AddAsync(extension);

            _logger.LogInformation($"Extension {extension.StudentId} created successfully.");
            return extension.ToDto();
        }

        /// <inheritdoc />
        public async Task<ExtensionInfoDto> GetExtensionAsync(Guid id)
        {
            var extensionEntity = await _repository.Extension.GetByIdAsync(id, x => x.Student);
            if (extensionEntity == null)
            {
                throw new ArgumentException("Extension not found.");
            }

            return extensionEntity.ToDto();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ExtensionInfoDto>> GetAllExtensionsAsync()
        {
            var extensions = await _repository.Extension.GetAllAsync(x => x.Student);
            var extensionDtos = new List<ExtensionInfoDto>();
            foreach (var extension in extensions)
            {
                extensionDtos.Add(extension.ToDto());
            }

            return extensionDtos;
        }

        /// <inheritdoc />
        public async Task<ExtensionInfoDto> UpdateExtensionAsync(Guid id, ExtensionDto extensionDto)
        {
            var existingExtension = await _repository.Extension.GetByIdAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            existingExtension = extensionDto.ToEntity(existingExtension);

            await _repository.Extension.UpdateAsync(existingExtension);

            return existingExtension.ToDto();
        }

        /// <inheritdoc />
        public async Task DeleteExtensionAsync(Guid id)
        {
            var existingExtension = await _repository.Extension.GetByIdAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            await _repository.Extension.DeactiveAsync(existingExtension);
        }
    }
}
