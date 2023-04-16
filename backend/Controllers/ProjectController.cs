using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Services.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="projectDto">The project data.</param>
        /// <returns>The created project.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator, ProjectManager")]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectDto projectDto)
        {
            try
            {
                var project = await _projectService.CreateProjectAsync(projectDto);
                return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets a project by its ID.
        /// </summary>
        /// <param name="id">The project ID.</param>
        /// <returns>The project.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, ProjectManager, Developer")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            try
            {
                var project = await _projectService.GetProjectAsync(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAllProjectsAsync()
        {
            var projectDtos = await _projectService.GetAllProjectsAsync();

            return Ok(projectDtos);
        }

        /// <summary>
        /// Updates a project by its ID.
        /// </summary>
        /// <param name="id">The project ID.</param>
        /// <param name="projectDto">The project data.</param>
        /// <returns>The updated project.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, ProjectManager")]
        public async Task<ActionResult<ProjectDto>> UpdateProject(int id, ProjectDto projectDto)
        {
            try
            {
                var project = await _projectService.UpdateProjectAsync(id, projectDto);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a project by its ID.
        /// </summary>
        /// <param name="id">The project ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, ProjectManager")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
