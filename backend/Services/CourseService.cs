using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Models;
using gerdisc.Models.DTOs;
using gerdisc.Models.Mapper;
using Microsoft.Extensions.Logging;

namespace gerdisc.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IRepository _repository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IRepository repository, ILogger<CourseService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CourseDto> CreateCourseAsync(CourseDto courseDto)
        {
            var count = await _repository.Course.CountAsync();
            courseDto.Id = count + 1;

            var course = courseDto.ToEntity();

            await _repository.Course.AddAsync(course);
            await _repository.Course.CommitAsync();

            _logger.LogInformation($"Course {course.Name} created successfully.");

            return course.ToDto();
        }

        public async Task<CourseDto> GetCourseAsync(int id)
        {
            var courseEntity = await _repository.Course.GetSingleAsync(id);
            if (courseEntity == null)
            {
                throw new ArgumentException($"Course with id {id} not found.");
            }

            return courseEntity.ToDto();
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync()
        {
            var courses = await _repository.Course.GetAllAsync();
            var courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                courseDtos.Add(course.ToDto());
            }

            return courseDtos;
        }

        public async Task<CourseDto> UpdateCourseAsync(int id, CourseDto courseDto)
        {
            var existingCourse = await _repository.Course.GetSingleAsync(id);
            if (existingCourse == null)
            {
                throw new ArgumentException($"Course with id {id} does not exist.");
            }

            existingCourse = courseDto.ToEntity(existingCourse);

            await _repository.Course.CommitAsync();

            return existingCourse.ToDto();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var existingCourse = await _repository.Course.GetSingleAsync(id);
            if (existingCourse == null)
            {
                throw new ArgumentException($"Course with id {id} does not exist.");
            }

            _repository.Course.Delete(existingCourse);
            await _repository.Course.CommitAsync();
        }
    }
}
