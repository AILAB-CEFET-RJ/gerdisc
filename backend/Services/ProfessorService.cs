using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Mapper;

namespace gerdisc.Services.Professor
{
    public class ProfessorService : IProfessorService
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProfessorService> _logger;

        public ProfessorService(
            IRepository repository,
            ILogger<ProfessorService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProfessorDto> CreateProfessorAsync(ProfessorDto professorDto)
        {
            var professor = professorDto.ToEntity();
            var user = await _repository.User.AddAsync(professor.User);
            professor.UserId = user.Id;
            await _repository.Professor.AddAsync(professor);

            _logger.LogInformation($"Professor {professor.User.Id} created successfully.");
            return professorDto;
        }

        public async Task<ProfessorDto> GetProfessorAsync(Guid id)
        {
            var professorEntity = await _repository.Professor.GetByIdAsync(id, x => x.User);
            if (professorEntity == null)
            {
                throw new ArgumentException("Professor not found.");
            }

            return professorEntity.ToDto();
        }

        public async Task<IEnumerable<ProfessorDto>> GetAllProfessorsAsync()
        {
            var professors = await _repository.Professor.GetAllAsync(x => x.User);
            var professorDtos = new List<ProfessorDto>();
            foreach (var professor in professors)
            {
                professorDtos.Add(professor.ToDto());
            }

            return professorDtos;
        }

        public async Task<ProfessorDto> UpdateProfessorAsync(Guid id, ProfessorDto professorDto)
        {
            var existingProfessor = await _repository.Professor.GetByIdAsync(id);
            if (existingProfessor == null)
            {
                throw new ArgumentException($"Professor with id {id} does not exist.");
            }

            existingProfessor = professorDto.ToEntity(existingProfessor);


            return existingProfessor.ToDto();
        }

        public async Task DeleteProfessorAsync(Guid id)
        {
            var existingProfessor = await _repository.Professor.GetByIdAsync(id);
            if (existingProfessor == null)
            {
                throw new ArgumentException($"Professor with id {id} does not exist.");
            }

            await _repository.Professor.DeactiveAsync(existingProfessor);
        }
    }
}
