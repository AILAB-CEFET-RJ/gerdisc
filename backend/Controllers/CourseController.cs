using gerdisc.Models.DTOs;
using gerdisc.Services.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        }

        /// <summary>
        /// Creates a new course.
        /// </summary>
        /// <param name="courseDto">The DTO containing the course information.</param>
        /// <returns>The newly created course.</returns>
        /// <response code="201">Returns the newly created course.</response>
        /// <response code="400">If the request data is invalid.</response>
        [HttpPost]
        [Authorize(Roles = "Administrator, Professor")]
        [ProducesResponseType(typeof(CourseDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCourse(CourseDto courseDto)
        {
            try
            {
                var course = await _courseService.CreateCourseAsync(courseDto);
                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Gets the details of a course.
        /// </summary>
        /// <param name="id">The id of the course.</param>
        /// <returns>The details of the course.</returns>
        /// <response code="200">Returns the details of the course.</response>
        /// <response code="404">If the course is not found.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, Professor, Student")]
        [ProducesResponseType(typeof(CourseDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCourse(int id)
        {
            try
            {
                var course = await _courseService.GetCourseAsync(id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates the details of a course.
        /// </summary>
        /// <param name="id">The id of the course.</param>
        /// <param name="courseDto">The DTO containing the new course information.</param>
        /// <returns>The updated course.</returns>
        /// <response code="200">Returns the updated course.</response>
        /// <response code="400">If the request data is invalid.</response>
        /// <response code="404">If the course is not found.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator, Professor")]
        [ProducesResponseType(typeof(CourseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCourse(int id, CourseDto courseDto)
        {
            try
            {
                var course = await _courseService.UpdateCourseAsync(id, courseDto);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes a course with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the course to delete.</param>
        /// <returns>A task representing the asynchronous operation. Returns IActionResult with NoContentResult if successful.</returns>
        /// <response code="204">Indicates that the course was successfully deleted.</response>
        /// <response code="400">Indicates that there was an error deleting the course.</response>
        /// <response code="401">Indicates that the user is not authorized to perform this action.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator, Professor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}