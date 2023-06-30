using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="OrientationDto"/> and <see cref="OrientationEntity"/> objects.
    /// </summary>
    public static class OrientationMapper
    {
        /// <summary>
        /// Converts a <see cref="CreateOrientationDto"/> object to a <see cref="OrientationEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateOrientationDto"/> object to convert.</param>
        /// <returns>A new <see cref="OrientationEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static OrientationEntity ToEntity(this CreateOrientationDto self) =>
            self is null ? new OrientationEntity() : new OrientationEntity
            {
                ProfessorId = self.ProfessorId,
                CoorientatorId = self.CoorientatorId,
                Dissertation = self.Dissertation,
                ProjectId = self.ProjectId,
                StudentId = self.StudentId
            };

        /// <summary>
        /// Updates the values of an existing <see cref="OrientationEntity"/> object using the values from a <see cref="CreateOrientationDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateOrientationDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="OrientationEntity"/> object to update.</param>
        /// <returns>The updated <see cref="OrientationEntity"/> object.</returns>
        public static OrientationEntity ToEntity(this CreateOrientationDto self, OrientationEntity entityToUpdate)
        {
            entityToUpdate.CoorientatorId = self.CoorientatorId;
            entityToUpdate.ProfessorId = self.ProfessorId;
            entityToUpdate.Dissertation = self.Dissertation;
            entityToUpdate.ProjectId = self.ProjectId;
            entityToUpdate.StudentId = self.StudentId;
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="OrientationEntity"/> object to a <see cref="OrientationDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="OrientationEntity"/> object to convert.</param>
        /// <returns>A new <see cref="OrientationDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static OrientationDto ToDto(this OrientationEntity self) =>
            self is null ? new OrientationDto() : new OrientationDto
            {
                Id = self.Id,
                Dissertation = self.Dissertation,
                CoorientatorId = self.CoorientatorId,
                ProfessorId = self.ProfessorId,
                ProjectId = self.ProjectId,
                StudentId = self.StudentId,
                Coorientator = self.Coorientator?.ToUserDto(),
                Professor = self.Professor?.ToUserDto(),
                Student = self.Student?.ToUserDto()
            };
    }
}
