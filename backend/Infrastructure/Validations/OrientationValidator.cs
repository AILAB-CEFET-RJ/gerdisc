using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for orientations.
    /// </summary>
    public class OrientationValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientationValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public OrientationValidator(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Determines whether a dissertation can be added to a project in the given orientation.
        /// </summary>
        /// <param name="orientationDto">The orientation DTO containing the dissertation and student IDs.</param>
        /// <returns>A tuple with a boolean indicating whether the dissertation can be added, and a message describing the result.</returns>
        public async Task<(bool, string)> CanAddDissertationToProject(OrientationDto orientationDto)
        {
            var project = await _repository.Project.GetByIdAsync(orientationDto.Dissertation.ProjectId);
            var student = await _repository.Student.GetByIdAsync(orientationDto.Dissertation.StudentId);

            if (project == null || student == null)
            {
                return (false, "Project or student not found.");
            }

            // Check if the student is already associated with the project
            if (student.ProjectId != project.Id)
            {
                return (false, "Student is not associated with the project.");
            }

            return (true, "Success.");
        }
    }
}
