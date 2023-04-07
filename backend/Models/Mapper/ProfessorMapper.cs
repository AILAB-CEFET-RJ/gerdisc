using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="ProfessorDto"/> and <see cref="ProfessorEntity"/> objects.
    /// </summary>
    public static class ProfessorMapper
    {
        /// <summary>
        /// Converts a <see cref="ProfessorDto"/> object to a <see cref="ProfessorEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProfessorDto"/> object to convert.</param>
        /// <returns>A new <see cref="ProfessorEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProfessorEntity ToEntity(this ProfessorDto self) =>
            self is null ? new ProfessorEntity() : new ProfessorEntity
            {
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ProfessorEntity"/> object using the values from a <see cref="ProfessorDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProfessorDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ProfessorEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ProfessorEntity"/> object.</returns>
        public static ProfessorEntity ToEntity(this ProfessorDto self, ProfessorEntity entityToUpdate)
        {
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="ProfessorEntity"/> object to a <see cref="ProfessorDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProfessorEntity"/> object to convert.</param>
        /// <returns>A new <see cref="ProfessorDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProfessorDto ToDto(this ProfessorEntity self) =>
            self is null ? new ProfessorDto() : new ProfessorDto
            {
            };
    }
}
