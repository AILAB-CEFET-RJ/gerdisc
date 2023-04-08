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
            var count = await _repository.Project.CountAsync();
            projectDto.Id = count + 1;

            var project = projectDto.ToEntity();

            await _repository.Project.AddAsync(project);
            await _repository.Project.CommitAsync();

            _logger.LogInformation($"Project {project.Name} created successfully.");
            return projectDto;
        }

        public async Task<ProjectDto> GetProjectAsync(int id)
        {
            var projectEntity = await _repository.Project.GetSingleAsync(id);
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

        public async Task<ProjectDto> UpdateProjectAsync(int id, ProjectDto projectDto)
        {
            var existingProject = await _repository.Project.GetSingleAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            existingProject = projectDto.ToEntity(existingProject);

            await _repository.Project.CommitAsync();

            return existingProject.ToDto();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var existingProject = await _repository.Project.GetSingleAsync(id);
            if (existingProject == null)
            {
                throw new ArgumentException($"Project with id {id} does not exist.");
            }

            _repository.Project.Delete(existingProject);
            await _repository.Project.CommitAsync();
        }
    }
}
