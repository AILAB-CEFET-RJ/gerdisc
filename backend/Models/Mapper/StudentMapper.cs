using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Infrastructure.Extensions;
using gerdisc.Models.Enums;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="StudentDto"/> and <see cref="StudentEntity"/> objects.
    /// </summary>
    public static class StudentMapper
    {
        /// <summary>
        /// Converts a <see cref="StudentDto"/> object to a <see cref="StudentEntity"/> object.
        /// </summary>
        /// <param name="dto">The <see cref="StudentDto"/> object to convert.</param>
        /// <returns>A new <see cref="StudentEntity"/> object with the values from the <paramref name="dto"/> object.</returns>
        public static StudentEntity ToEntity(this StudentDto dto, Guid userId) =>
            dto is null ? new StudentEntity() : new StudentEntity
            {
                Id = userId,
                Registration = dto.Registration,
                RegistrationDate = dto.RegistrationDate?.ToUniversalTime(),
                ProjectId = dto.ProjectId,
                Status = dto.Status,
                EntryDate = dto.EntryDate?.ToUniversalTime(),
                ProjectDefenceDate = dto.ProjectDefenceDate?.ToUniversalTime(),
                ProjectQualificationDate = dto.ProjectQualificationDate?.ToUniversalTime(),
                Proficiency = dto.Proficiency,
                UndergraduateInstitution = dto.UndergraduateInstitution,
                InstitutionType = dto.InstitutionType,
                UndergraduateCourse = dto.UndergraduateCourse,
                GraduationYear = dto.GraduationYear,
                UndergraduateArea = dto.UndergraduateArea,
                DateOfBirth = dto.DateOfBirth?.ToUniversalTime(),
                Scholarship = dto.Scholarship,
                StudentCourses = dto.StudentCourses?.Select(x => x.ToEntity()) ?? new List<StudentCourseEntity>(),
                UserId = userId
            };

        /// <summary>
        /// Updates the values of an existing <see cref="StudentEntity"/> object using the values from a <see cref="StudentDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="StudentDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="StudentEntity"/> object to update.</param>
        /// <returns>The updated <see cref="StudentEntity"/> object.</returns>
        public static StudentEntity ToEntity(this StudentDto self, StudentEntity entityToUpdate)
        {
            entityToUpdate.ProjectId = self.ProjectId;
            entityToUpdate.Status = self.Status;
            entityToUpdate.EntryDate = self.EntryDate;
            entityToUpdate.ProjectDefenceDate = self.ProjectDefenceDate;
            entityToUpdate.ProjectQualificationDate = self.ProjectQualificationDate;
            entityToUpdate.Proficiency = self.Proficiency;
            entityToUpdate.UndergraduateInstitution = self.UndergraduateInstitution;
            entityToUpdate.InstitutionType = self.InstitutionType;
            entityToUpdate.UndergraduateCourse = self.UndergraduateCourse;
            entityToUpdate.GraduationYear = self.GraduationYear;
            entityToUpdate.UndergraduateArea = self.UndergraduateArea;
            entityToUpdate.DateOfBirth = self.DateOfBirth;
            entityToUpdate.Scholarship = self.Scholarship;
            
            var coursesToAdd = self.StudentCourses?
                .Where(x => !entityToUpdate.StudentCourses.Select(sc => sc.CourseId).Contains(x.CourseId))
                .Select(x => x.ToEntity()) ?? new List<StudentCourseEntity>();

            entityToUpdate.StudentCourses = entityToUpdate.StudentCourses.Concat(coursesToAdd);
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="StudentEntity"/> object to a <see cref="StudentDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="StudentEntity"/> object to convert.</param>
        /// <returns>A new <see cref="StudentDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static StudentDto ToDto(this StudentEntity self)
        {
            var entity = self is null ? new StudentDto() : new StudentDto
            {
                Registration = self.Registration,
                RegistrationDate = self.RegistrationDate?.ToUniversalTime(),
                ProjectId = self.ProjectId,
                Status = self.Status,
                EntryDate = self.EntryDate?.ToUniversalTime(),
                ProjectDefenceDate = self.ProjectDefenceDate?.ToUniversalTime(),
                ProjectQualificationDate = self.ProjectQualificationDate?.ToUniversalTime(),
                Proficiency = self.Proficiency,
                UndergraduateInstitution = self.UndergraduateInstitution,
                InstitutionType = self.InstitutionType,
                UndergraduateCourse = self.UndergraduateCourse,
                GraduationYear = self.GraduationYear,
                UndergraduateArea = self.UndergraduateArea,
                DateOfBirth = self.DateOfBirth?.ToUniversalTime(),
                Scholarship = self.Scholarship,
                StudentCourses = self.StudentCourses.Select(x => x.ToDto())
            };
            return entity.AddUserDto(self.User);
        }

        /// <summary>
        /// Converts a <see cref="StudentCsvDto"/> object to a <see cref="StudentDto"/> object.
        /// </summary>
        /// <param name="entity">The <see cref="StudentCsvDto"/> object to convert.</param>
        /// <returns>A new <see cref="StudentDto"/> object with the values from the <paramref name="entity"/> object.</returns>
        public static StudentDto ToDto(this StudentCsvDto entity) =>
            entity is null ? new StudentDto() : new StudentDto
            {
                Registration = entity.Registration,
                RegistrationDate = entity.RegistrationDate.Parse()?.ToUniversalTime(),
                // ProjectId = entity.ProjectId, Tem que arrumar aqui, provavlmente a planilha não tera Id
                Status = entity.Status,
                EntryDate = entity.EntryDate.Parse()?.ToUniversalTime(),
                ProjectDefenceDate = entity.ProjectDefenceDate.Parse()?.ToUniversalTime(),
                ProjectQualificationDate = entity.ProjectQualificationDate.Parse()?.ToUniversalTime(),
                Proficiency = entity.Proficiency,
                UndergraduateInstitution = entity.UndergraduateInstitution,
                InstitutionType = entity.InstitutionType,
                UndergraduateCourse = entity.UndergraduateCourse,
                GraduationYear = entity.GraduationYear,
                UndergraduateArea = entity.UndergraduateArea,
                DateOfBirth = entity.DateOfBirth.Parse()?.ToUniversalTime(),
                Scholarship = entity.Scholarship,
                Cpf = entity.Cpf,
                Email = entity.Email,
                FirstName = entity.Name?.Split(' ').FirstOrDefault(),
                LastName = entity.Name?.Split(' ').LastOrDefault(),
            };
    }
}
