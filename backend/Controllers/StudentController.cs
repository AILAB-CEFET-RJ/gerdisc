using Microsoft.AspNetCore.Mvc;
using gerdisc.Models.DTOs;
using gerdisc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, StudentManager")]
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto studentDto)
        {
            try
            {
                var student = await _studentService.CreateStudentAsync(studentDto);
                return CreatedAtAction(nameof(GetStudent), new { studentId = student.Id }, student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        [Authorize(Roles = "Administrator, StudentManager")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPut("{studentId}")]
        [Authorize(Roles = "Administrator, StudentManager")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(Guid studentId, StudentDto studentDto)
        {
            var updatedStudentDto = await _studentService.UpdateStudentAsync(studentId, studentDto);
            if (updatedStudentDto == null) return NotFound();
            return Ok(updatedStudentDto);
        }

        [HttpDelete("{studentId}")]
        [Authorize(Roles = "Administrator, StudentManager")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            var studentDto = await _studentService.GetStudentAsync(studentId);
            if (studentDto == null) return NotFound();
            await _studentService.DeleteStudentAsync(studentId);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, StudentManager")]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            var studentDtos = await _studentService.GetAllStudentsAsync();

            return Ok(studentDtos);
        }
    }
}
