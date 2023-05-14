using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using gerdisc.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using CsvHelper;
using System.Globalization;

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
            var user = await _repository.User.GetUserByEmail(studentDto.Email);
            if (user is not null)
            {
                throw new ArgumentException($"Student {studentDto.Email} alredy created.");
            }

            var student = studentDto.ToEntity();
            user = await _repository.User.AddAsync(student.User);

            student.UserId = user.Id;
            student = await _repository.Student.AddAsync(student);

            _logger.LogInformation($"Student {studentDto.Email} created successfully.");
            return student.ToDto();
        }

        public async Task<IEnumerable<StudentDto>> AddStudentsFromCsvAsync(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = await csv.GetRecordsAsync<StudentCsvDto>().ToListAsync();

            var insertedStudents = new List<StudentDto>();
            foreach (var record in records)
            {
                try
                {
                    var insertedStudent = await CreateStudentAsync(record.ToDto());
                    insertedStudents.Add(insertedStudent);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex.Message);
                }
            }

            return insertedStudents;
        }

        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            var studentEntity = await _repository.Student.GetByIdAsync(id, s => s.User);
            if (studentEntity == null)
            {
                throw new ArgumentException("Student not found.");
            }

            return studentEntity.ToDto();
        }

        public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _repository.Student.GetAllAsync(s => s.User);
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
