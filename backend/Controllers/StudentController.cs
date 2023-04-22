using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Services.Interfaces;
using gerdisc.Services.Student;
using gerdisc.Infrastructure.Repositories;

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
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<StudentDto>> CreateStudentAsync(StudentDto studentDto)
        {
            var createdStudentDto = await _studentService.CreateStudentAsync(studentDto);

            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = createdStudentDto.Id.Value.ToString() }, createdStudentDto);
        }

        [HttpGet("{studentId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentDto>> GetStudentAsync(Guid studentId)
        {
            var studentDto = await _studentService.GetStudentAsync(studentId);

            if (studentDto == null)
            {
                return NotFound();
            }

            return Ok(studentDto);
        }

        [HttpPut("{studentId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentDto>> UpdateStudentAsync(Guid studentId, StudentDto studentDto)
        {
            var updatedStudentDto = await _studentService.UpdateStudentAsync(studentId, studentDto);

            if (updatedStudentDto == null)
            {
                return NotFound();
            }

            return Ok(updatedStudentDto);
        }

        [HttpDelete("{studentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudentAsync(Guid studentId)
        {
            var studentDto = await _studentService.GetStudentAsync(studentId);

            if (studentDto == null)
            {
                return NotFound();
            }

            await _studentService.DeleteStudentAsync(studentId);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync()
        {
            var studentDtos = await _studentService.GetAllStudentsAsync();

            return Ok(studentDtos);
        }
    }
}
