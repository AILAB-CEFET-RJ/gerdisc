using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using CsvHelper;
using System.Globalization;
using gerdisc.Services.Interfaces;

namespace gerdisc.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository _repository;
        private readonly ILogger<StudentService> _logger;
        private readonly IUserService _userService;

        public StudentService(
            IRepository repository,
            ILogger<StudentService> logger,
            IUserService userService
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <inheritdoc />
        public async Task<StudentDto> CreateStudentAsync(StudentDto studentDto)
        {
            var user = await _userService.CreateUserAsync(studentDto);
            var student = studentDto.ToEntity(user.Id);

            student = await _repository.Student.AddAsync(student);

            _logger.LogInformation($"Student {studentDto.Email} created successfully.");
            return student.ToDto();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            var studentEntity = await _repository.Student.GetByIdAsync(id, s => s.User);
            if (studentEntity == null)
            {
                throw new ArgumentException("Student not found.");
            }

            return studentEntity.ToDto();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<StudentDto> UpdateStudentAsync(Guid id, StudentDto studentDto)
        {
            var existingStudent = await _repository.Student.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            existingStudent = studentDto.ToEntity(existingStudent);

            await _repository.Student.UpdateAsync(existingStudent);

            return existingStudent.ToDto();
        }

        /// <inheritdoc />
        public async Task DeleteStudentAsync(Guid id)
        {
            var existingStudent = await _repository.Student.GetByIdAsync(id);
            if (existingStudent == null)
            {
                throw new ArgumentException($"Student with id {id} does not exist.");
            }

            await _repository.Student.DeactiveAsync(existingStudent);
        }
    }
}
