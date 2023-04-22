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

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto projectDto)
        {
            var project = projectDto.ToEntity();

            await _repository.Project.AddAsync(project);

            _logger.LogInformation($"Project {project.Name} created successfully.");
            return projectDto;
        }

        public async Task<ProjectDto> GetProjectAsync(Guid id)
        {
            var projectEntity = await _repository.Project.GetByIdAsync(id);
            if (projectEntity == null)
            {
                throw new ArgumentException("Project not found.");
            }

            return projectEntity.ToDto();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _repository.Project.GetAllAsync();
            var projectDtos = new List<ProjectDto>();
            foreach (var project in projects)
            {
                projectDtos.Add(project.ToDto());
            }

            return projectDtos;
        }

        public async Task<ProjectDto> UpdateProjectAsync(Guid id, ProjectDto projectDto)
        {
            var existingProject = await _repository.Project.GetByIdAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            existingProject = projectDto.ToEntity(existingProject);


            return existingProject.ToDto();
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var existingProject = await _repository.Project.GetByIdAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            await _repository.Project.DeleteAsync(existingProject);
        }
    }
}
