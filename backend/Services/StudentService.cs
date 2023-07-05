using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using CsvHelper;
using System.Globalization;
using gerdisc.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

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
        public async Task<StudentDto> CreateStudentAsync(CreateStudentDto studentDto)
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
            var records = CastFromCsvAsync<StudentCsvDto>(file);

            var insertedStudents = new List<StudentDto>();
            await foreach (var record in records)
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
        public async Task<IEnumerable<StudentCourseDto>> AddCoursesToStudentsFromCsvAsync(IFormFile file)
        {
            var records = CastFromCsvAsync<StudentCourseCsvDto>(file);

            var courseNames = await records.Select(x => x.CourseUnique).ToListAsync();
            var courses = await _repository.Course.GetAllAsync(x => courseNames.Contains(x.CourseUnique));
            var courseDictionary = courses?.ToDictionary(x => x.CourseUnique, x => x.Id);

            var studentRegistrations = await records.Select(x => x.StudentRegistration).ToListAsync();
            var students = await _repository.Student.GetAllAsync(x => studentRegistrations.Contains(x.Registration));
            var studentDictionary = students?.ToDictionary(x => x.Registration, x => x.Id);

            var insertedCourses = new List<StudentCourseDto>();

            await foreach (var record in records)
            {
                if (studentDictionary.TryGetValue(record.StudentRegistration, out var student) &&
                    courseDictionary.TryGetValue(record.CourseUnique, out var courseId))
                {
                    var course = await _repository.StudentCourse.AddAsync(record.ToDto(courseId, student).ToEntity());
                    insertedCourses.Add(course.ToDto());
                }
                else
                {
                    _logger.LogWarning($"Failed to add course to student: {record.StudentRegistration} - {record.CourseName}");
                }
            }

            return insertedCourses;
        }

        /// <inheritdoc />
        public async Task<StudentDto> GetStudentAsync(Guid id)
        {
            var studentEntity = await _repository.Student.GetByIdAsync(id, s => s.User, s => s.Project);
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
        public async Task<StudentDto> UpdateStudentAsync(Guid id, CreateStudentDto studentDto)
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

        public async IAsyncEnumerable<TDTO> CastFromCsvAsync<TDTO>(IFormFile file)
            where TDTO: class
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = await csv.GetRecordsAsync<TDTO>().ToListAsync();

            foreach (var record in records)
            {
                var validationContext = new ValidationContext(record);
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateObject(record, validationContext, validationResults, true))
                {
                    yield return record;
                }
                else
                {
                    var errorMessages = validationResults.Select(result => result.ErrorMessage);
                    _logger.LogWarning($"Validation failed for record: {string.Join(", ", errorMessages)}");
                }
            }
        }
    }
}
