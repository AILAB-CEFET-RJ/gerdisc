using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

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
        public static StudentEntity ToEntity(this StudentDto dto) =>
            dto is null ? new StudentEntity() : new StudentEntity
            {
                Id = dto.Id,
                Registration = dto.Registration,
                RegistrationDate = dto.RegistrationDate,
                ProjectId = dto.ProjectId,
                Status = dto.Status,
                EntryDate = dto.EntryDate,
                ProjectDefenceDate = dto.ProjectDefenceDate,
                ProjectQualificationDate = dto.ProjectQualificationDate,
                Proficiency = dto.Proficiency,
                UndergraduateInstitution = dto.UndergraduateInstitution,
                InstitutionType = dto.InstitutionType,
                UndergraduateCourse = dto.UndergraduateCourse,
                GraduationYear = dto.GraduationYear,
                UndergraduateArea = dto.UndergraduateArea,
                DateOfBirth = dto.DateOfBirth,
                Scholarship = dto.Scholarship
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
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="StudentEntity"/> object to a <see cref="StudentDto"/> object.
        /// </summary>
        /// <param name="entity">The <see cref="StudentEntity"/> object to convert.</param>
        /// <returns>A new <see cref="StudentDto"/> object with the values from the <paramref name="entity"/> object.</returns>
        public static StudentDto ToDto(this StudentEntity entity) =>
            entity is null ? new StudentDto() : new StudentDto
            {
                Id = entity.Id,
                Registration = entity.Registration,
                RegistrationDate = entity.RegistrationDate,
                ProjectId = entity.ProjectId,
                Status = entity.Status,
                EntryDate = entity.EntryDate,
                ProjectDefenceDate = entity.ProjectDefenceDate,
                ProjectQualificationDate = entity.ProjectQualificationDate,
                Proficiency = entity.Proficiency,
                UndergraduateInstitution = entity.UndergraduateInstitution,
                InstitutionType = entity.InstitutionType,
                UndergraduateCourse = entity.UndergraduateCourse,
                GraduationYear = entity.GraduationYear,
                UndergraduateArea = entity.UndergraduateArea,
                DateOfBirth = entity.DateOfBirth,
                Scholarship = entity.Scholarship
            };
    }
}
