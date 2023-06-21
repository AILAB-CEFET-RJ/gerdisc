using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    public class OrientationValidator
    {
        private readonly IRepository _repository;

        public OrientationValidator(IRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
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