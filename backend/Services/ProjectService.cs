using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gerdisc.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository _repository;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IRepository repository,
            ILogger<ProjectService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateProjectAsync(CreateProjectDto projectDto)
        {
            var project = projectDto.ToEntity();

            var professorIds = projectDto.ProfessorIds.Select(x => Guid.Parse(x));

            project = await _repository.Project.AddAsync(project);
            await _repository.ProfessorProject.AddRangeAsync(professorIds.CreateProfessorProjects(project.Id));

            _logger.LogInformation($"Project {project.Name} created successfully.");
            return project.Id;
        }

        public async Task<ProjectDto> GetProjectAsync(Guid id)
        {
            var projectEntity = await _repository
                .Project
                .GetByIdAsync(id);
            if (projectEntity == null)
            {
                throw new ArgumentException("Project not found.");
            }

            return projectEntity.ToDto();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _repository
                .Project
                .GetAllAsync(x => x.Dissertations);
            var projectDtos = new List<ProjectDto>();
            foreach (var project in projects)
            {
                projectDtos.Add(project.ToDto());
            }

            return projectDtos;
        }

        public async Task<Guid> UpdateProjectAsync(Guid id, CreateProjectDto projectDto)
        {
            var existingProject = await _repository.Project.GetByIdAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            var professorIds = projectDto
                .ProfessorIds
                .Select(x => Guid.Parse(x))
                .Except(existingProject.ProfessorProjects.Select(x => x.Id));

            var professorIdsToDelete = existingProject
                .ProfessorProjects
                .Select(x => x.Id)
                .Except(
                    projectDto
                    .ProfessorIds
                    .Select(x => Guid.Parse(x)));

            await _repository.ProfessorProject.DeactiveRangeAsync(entity => professorIdsToDelete.Contains(entity.Id));

            existingProject = projectDto.ToEntity(existingProject);
            await _repository.ProfessorProject.AddRangeAsync(professorIds.CreateProfessorProjects(existingProject.Id));

            return existingProject.Id;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var existingProject = await _repository.Project.GetByIdAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            await _repository.Project.DeactiveAsync(existingProject);
        }
    }
}
