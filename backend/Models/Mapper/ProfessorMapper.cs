using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Enums;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="CreateProfessorDto"/> and <see cref="ProfessorEntity"/> objects.
    /// </summary>
    public static class ProfessorMapper
    {
        /// <summary>
        /// Converts a <see cref="CreateProfessorDto"/> object to a <see cref="ProfessorEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateProfessorDto"/> object to convert.</param>
        /// <returns>A new <see cref="ProfessorEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProfessorEntity ToEntity(this CreateProfessorDto self, Guid userId) =>
            self is null ? new ProfessorEntity() : new ProfessorEntity
            {
                Id = userId,
                Siape = self.Siape,
                UserId = userId,
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ProfessorEntity"/> object using the values from a <see cref="CreateProfessorDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateProfessorDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ProfessorEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ProfessorEntity"/> object.</returns>
        public static ProfessorEntity ToEntity(this CreateProfessorDto self, ProfessorEntity entityToUpdate)
        {
            entityToUpdate.Siape = self.Siape;
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
                Siape = self.Siape,
            }.AddUserDto(self.User);
    }
}
