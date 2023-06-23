using gerdisc.Infrastructure.Repositories;
using gerdisc.Infrastructure.Validations;
using gerdisc.Models.DTOs;
using gerdisc.Models.Mapper;
using gerdisc.Services.Interfaces;

namespace gerdisc.Services
{
    public class OrientationService : IOrientationService
    {
        private readonly IRepository _repository;
        private readonly ILogger<OrientationService> _logger;
        private readonly OrientationValidator _validator;

        public OrientationService(
            IRepository repository,
            ILogger<OrientationService> logger,
            OrientationValidator validator
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <inheritdoc />
        public async Task<OrientationDto> CreateOrientationAsync(CreateOrientationDto orientationDto)
        {
            (var isValid, var message) = await _validator.CanAddOrientationToProject(orientationDto);
            if(!isValid)
            {
                throw new ArgumentException(message);
            }

            var orientation = await _repository.Orientation.AddAsync(orientationDto.ToEntity());

            _logger.LogInformation($"Orientation {orientation.Id} created successfully.");
            return orientation.ToDto();
        }

        /// <inheritdoc />
        public async Task<OrientationDto> GetOrientationAsync(Guid id)
        {
            var orientationEntity = await _repository.Orientation.GetByIdAsync(id, x => x.Professor, x => x.Coorientator);
            if (orientationEntity == null)
            {
                throw new ArgumentException("Orientation not found.");
            }

            return orientationEntity.ToDto();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<OrientationDto>> GetAllOrientationsAsync()
        {
            var orientations = await _repository.Orientation.GetAllAsync(x => x.Professor, x => x.Coorientator);
            var orientationDtos = new List<OrientationDto>();
            foreach (var orientation in orientations)
            {
                orientationDtos.Add(orientation.ToDto());
            }

            return orientationDtos;
        }

        /// <inheritdoc />
        public async Task<OrientationDto> UpdateOrientationAsync(Guid id, CreateOrientationDto orientationDto)
        {
            var existingOrientation = await _repository.Orientation.GetByIdAsync(id);
            if (existingOrientation == null)
            {
                throw new ArgumentException($"Orientation with id {id} does not exist.");
            }

            existingOrientation = orientationDto.ToEntity(existingOrientation);

            await _repository.Orientation.UpdateAsync(existingOrientation);

            return existingOrientation.ToDto();
        }

        /// <inheritdoc />
        public async Task DeleteOrientationAsync(Guid id)
        {
            var existingOrientation = await _repository.Orientation.GetByIdAsync(id);
            if (existingOrientation == null)
            {
                throw new ArgumentException($"Orientation with id {id} does not exist.");
            }

            await _repository.Orientation.DeactiveAsync(existingOrientation);
        }
    }
}
