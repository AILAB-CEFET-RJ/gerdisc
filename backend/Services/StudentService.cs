using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using gerdisc.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gerdisc.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository _repository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(
            IRepository repository,
            ILogger<StudentService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<StudentDto> CreateStudentAsync(StudentDto studentDto)
        {
            var user = studentDto.User.ToEntity();
            user = await _repository.User.AddAsync(user);

            var student = studentDto.ToEntity();
            student.UserId = user.Id;
            student = await _repository.Student.AddAsync(student);

            _logger.LogInformation($"Student {student.User.Id} created successfully.");
            return student.ToDto();
        }

        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            var studentEntity = await _repository.Student.GetByIdAsync(id);
            if (studentEntity == null)
            {
                throw new ArgumentException("Student not found.");
            }

            return studentEntity.ToDto();
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.Student.GetAllAsync();
            var studentDtos = new List<StudentDto>();
            foreach (var student in students)
            {
                studentDtos.Add(student.ToDto());
            }

            return studentDtos;
        }

        public async Task<StudentDto> UpdateStudentAsync(Guid id, StudentDto studentDto)
        {
            var existingStudent = await _repository.Student.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            existingStudent = studentDto.ToEntity(existingStudent);


            return existingStudent.ToDto();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var existingStudent = await _repository.Student.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            await _repository.Student.DeleteAsync(existingStudent);
        }
    }
}
