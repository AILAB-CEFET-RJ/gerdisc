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
            var count = await _repository.Extension.CountAsync();
            extensionDto.Id = count + 1;

            var extension = extensionDto.ToEntity();

            await _repository.Extension.AddAsync(extension);
            await _repository.Extension.CommitAsync();

            _logger.LogInformation($"Extension {extension.StudentId} created successfully.");
            return extensionDto;
        }

        public async Task<ExtensionDto> GetExtensionAsync(int id)
        {
            var extensionEntity = await _repository.Extension.GetSingleAsync(id);
            if (extensionEntity == null)
            {
                throw new ArgumentException("Extension not found.");
            }

            return extensionEntity.ToDto();
        }

        public async Task<ExtensionDto> UpdateExtensionAsync(int id, ExtensionDto extensionDto)
        {
            var existingExtension = await _repository.Extension.GetSingleAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            existingExtension = extensionDto.ToEntity(existingExtension);

            await _repository.Extension.CommitAsync();

            return existingExtension.ToDto();
        }

        public async Task DeleteExtensionAsync(int id)
        {
            var existingExtension = await _repository.Extension.GetSingleAsync(id);
            if (existingExtension == null)
            {
                throw new ArgumentException($"Extension with id {id} does not exist.");
            }

            _repository.Extension.Delete(existingExtension);
            await _repository.Extension.CommitAsync();
        }
    }
}
