using gerdisc.Models.DTOs;
using gerdisc.Services;
using gerdisc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("professors")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        /// <summary>
        /// Creates a new professor.
        /// </summary>
        /// <param name="professorDto">The professor data.</param>
        /// <returns>The created professor.</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator, ProfessorManager")]
        public async Task<ActionResult<ProfessorDto>> CreateProfessor(ProfessorDto professorDto)
        {
            try
            {
                var professor = await _professorService.CreateProfessorAsync(professorDto);
                return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets a professor by its ID.
        /// </summary>
        /// <param name="id">The professor ID.</param>
        /// <returns>The professor.</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, ProfessorManager, Developer")]
        public async Task<ActionResult<ProfessorDto>> GetProfessor(Guid id)
        {
            try
            {
                var professor = await _professorService.GetProfessorAsync(id);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProfessorDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetAllProfessorsAsync()
        {
            var professorDtos = await _professorService.GetAllProfessorsAsync();

            return Ok(professorDtos);
        }

        /// <summary>
        /// Updates a professor by its ID.
        /// </summary>
        /// <param name="id">The professor ID.</param>
        /// <param name="professorDto">The professor data.</param>
        /// <returns>The updated professor.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, ProfessorManager")]
        public async Task<ActionResult<ProfessorDto>> UpdateProfessor(Guid id, ProfessorDto professorDto)
        {
            try
            {
                var professor = await _professorService.UpdateProfessorAsync(id, professorDto);
                return Ok(professor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a professor by its ID.
        /// </summary>
        /// <param name="id">The professor ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, ProfessorManager")]
        public async Task<IActionResult> DeleteProfessor(Guid id)
        {
            try
            {
                await _professorService.DeleteProfessorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
