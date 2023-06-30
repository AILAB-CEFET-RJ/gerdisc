using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Services;
using gerdisc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("orientations")]
    public class OrientationController : ControllerBase
    {
        private readonly IOrientationService _orientationService;

        public OrientationController(IOrientationService orientationService)
        {
            _orientationService = orientationService;
        }

        /// <summary>
        /// Creates a new orientation.
        /// </summary>
        /// <param name="orientationDto">The orientation data.</param>
        /// <returns>The created orientation.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<OrientationDto>> CreateOrientation(CreateOrientationDto orientationDto)
        {
            try
            {
                var orientation = await _orientationService.CreateOrientationAsync(orientationDto);
                return CreatedAtAction(nameof(GetOrientation), new { id = orientation.Id }, orientation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets a orientation by its ID.
        /// </summary>
        /// <param name="id">The orientation ID.</param>
        /// <returns>The orientation.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Student, Professor, ExternalResearcher")]
        public async Task<ActionResult<OrientationDto>> GetOrientation(Guid id)
        {
            try
            {
                var orientation = await _orientationService.GetOrientationAsync(id);
                return Ok(orientation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrientationDto>), StatusCodes.Status200OK)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<OrientationDto>>> GetAllOrientationsAsync()
        {
            var orientationDtos = await _orientationService.GetAllOrientationsAsync();

            return Ok(orientationDtos);
        }

        /// <summary>
        /// Updates a orientation by its ID.
        /// </summary>
        /// <param name="id">The orientation ID.</param>
        /// <param name="orientationDto">The orientation data.</param>
        /// <returns>The updated orientation.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<OrientationDto>> UpdateOrientation(Guid id, CreateOrientationDto orientationDto)
        {
            try
            {
                var orientation = await _orientationService.UpdateOrientationAsync(id, orientationDto);
                return Ok(orientation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a orientation by its ID.
        /// </summary>
        /// <param name="id">The orientation ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, ProjectManager")]
        public async Task<IActionResult> DeleteOrientation(Guid id)
        {
            try
            {
                await _orientationService.DeleteOrientationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
