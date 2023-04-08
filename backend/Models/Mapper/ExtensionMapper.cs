using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="ExtensionDto"/> and <see cref="ExtensionEntity"/> objects.
    /// </summary>
    public static class ExtensionMapper
    {
        /// <summary>
        /// Converts a <see cref="ExtensionDto"/> object to a <see cref="ExtensionEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ExtensionDto"/> object to convert.</param>
        /// <returns>A new <see cref="ExtensionEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ExtensionEntity ToEntity(this ExtensionDto self) =>
            self is null ? new ExtensionEntity() : new ExtensionEntity
            {
                Id = self.Id,
                Status = self.Status,
                NumberOfDays = self.NumberOfDays,
                StudentId = self.StudentId,
                Type = self.Type
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ExtensionEntity"/> object using the values from a <see cref="ExtensionDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ExtensionDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ExtensionEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ExtensionEntity"/> object.</returns>
        public static ExtensionEntity ToEntity(this ExtensionDto self, ExtensionEntity entityToUpdate)
        {
            entityToUpdate.Status = self.Status;
            entityToUpdate.NumberOfDays = self.NumberOfDays;
            entityToUpdate.StudentId = self.StudentId;
            entityToUpdate.Type = self.Type;
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="ExtensionEntity"/> object to a <see cref="ExtensionDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ExtensionEntity"/> object to convert.</param>
        /// <returns>A new <see cref="ExtensionDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ExtensionDto ToDto(this ExtensionEntity self) =>
            self is null ? new ExtensionDto() : new ExtensionDto
            {
                Id = self.Id,
                Status = self.Status,
                NumberOfDays = self.NumberOfDays,
                StudentId = self.StudentId,
                Type = self.Type
            };
    }
}