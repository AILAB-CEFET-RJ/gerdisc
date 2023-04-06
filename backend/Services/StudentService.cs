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
            var count = await _repository.Student.CountAsync();
            studentDto.Id = count + 1;

            var student = studentDto.ToEntity();

            await _repository.Student.AddAsync(student);
            await _repository.Student.CommitAsync();

            _logger.LogInformation($"Student {student.UserId} created successfully.");
            return studentDto;
        }

        public async Task<StudentDto> GetStudentAsync(int id)
        {
            var studentEntity = await _repository.Student.GetSingleAsync(id);
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

        public async Task<StudentDto> UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var existingStudent = await _repository.Student.GetSingleAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            existingStudent = studentDto.ToEntity(existingStudent);

            await _repository.Student.CommitAsync();

            return existingStudent.ToDto();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var existingStudent = await _repository.Student.GetSingleAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            _repository.Student.Delete(existingStudent);
            await _repository.Student.CommitAsync();
        }
    }
}
