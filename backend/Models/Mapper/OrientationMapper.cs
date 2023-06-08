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
        /// Converts a <see cref="OrientationDto"/> object to a <see cref="OrientationEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="OrientationDto"/> object to convert.</param>
        /// <returns>A new <see cref="OrientationEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static OrientationEntity ToEntity(this OrientationDto self) =>
            self is null ? new OrientationEntity() : new OrientationEntity
            {
                DissertationId = self.Dissertation.Id ?? Guid.Empty,
                ProfessorId = self.ProfessorId,
                ResearcherId = self.ResearcherId,
            };

        /// <summary>
        /// Updates the values of an existing <see cref="OrientationEntity"/> object using the values from a <see cref="OrientationDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="OrientationDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="OrientationEntity"/> object to update.</param>
        /// <returns>The updated <see cref="OrientationEntity"/> object.</returns>
        public static OrientationEntity ToEntity(this OrientationDto self, OrientationEntity entityToUpdate)
        {
            entityToUpdate.DissertationId = self.Dissertation.Id ?? Guid.Empty;
            entityToUpdate.ProfessorId = self.ProfessorId;
            entityToUpdate.ResearcherId = self.ResearcherId;
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
                ProfessorId = self.ProfessorId,
                Dissertation = self.Dissertation.ToDto(),
                ResearcherId = self.ResearcherId ?? Guid.Empty,
            };
    }
}
