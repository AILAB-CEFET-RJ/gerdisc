using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
            var count = await _repository.Professor.CountAsync();
            professorDto.Id = count + 1;

            var professor = professorDto.ToEntity();

            await _repository.Professor.AddAsync(professor);
            await _repository.Professor.CommitAsync();

            _logger.LogInformation($"Professor {professor.UserId} created successfully.");
            return professorDto;
        }

        public async Task<ProfessorDto> GetProfessorAsync(int id)
        {
            var professorEntity = await _repository.Professor.GetSingleAsync(id);
            if (professorEntity == null)
            {
                throw new ArgumentException("Professor not found.");
            }

            return professorEntity.ToDto();
        }

        public async Task<ProfessorDto> UpdateProfessorAsync(int id, ProfessorDto professorDto)
        {
            var existingProfessor = await _repository.Professor.GetSingleAsync(id);
            if (existingProfessor == null)
            {
                throw new ArgumentException($"Professor with id {id} does not exist.");
            }

            existingProfessor = professorDto.ToEntity(existingProfessor);

            await _repository.Professor.CommitAsync();

            return existingProfessor.ToDto();
        }

        public async Task DeleteProfessorAsync(int id)
        {
            var existingProfessor = await _repository.Professor.GetSingleAsync(id);
            if (existingProfessor == null)
            {
                throw new ArgumentException($"Professor with id {id} does not exist.");
            }

            _repository.Professor.Delete(existingProfessor);
            await _repository.Professor.CommitAsync();
        }
    }
}
