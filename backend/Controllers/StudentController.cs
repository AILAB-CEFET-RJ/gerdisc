using Microsoft.AspNetCore.Mvc;
using gerdisc.Models.DTOs;
using gerdisc.Services;
using Microsoft.AspNetCore.Authorization;
using gerdisc.Services.Interfaces;

namespace gerdisc.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
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

        [HttpPost("csv")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> AddStudentsFromCsvAsync(IFormFile file)
        {
            try
            {
                var students = await _studentService.AddStudentsFromCsvAsync(file);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<StudentDto>> GetStudent(Guid studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPut("{studentId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(Guid studentId, StudentDto studentDto)
        {
            var updatedStudentDto = await _studentService.UpdateStudentAsync(studentId, studentDto);
            if (updatedStudentDto == null) return NotFound();
            return Ok(updatedStudentDto);
        }

        [HttpDelete("{studentId}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            var studentDto = await _studentService.GetStudentAsync(studentId);
            if (studentDto == null) return NotFound();
            await _studentService.DeleteStudentAsync(studentId);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            var studentDtos = await _studentService.GetAllStudentsAsync();

            return Ok(studentDtos);
        }
    }
}
