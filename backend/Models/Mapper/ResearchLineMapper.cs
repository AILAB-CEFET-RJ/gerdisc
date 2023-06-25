using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="ResearchLineDto"/> and <see cref="ResearchLineEntity"/> objects.
    /// </summary>
    public static class ResearchLineMapper
    {
        /// <summary>
        /// Converts a <see cref="CreateResearchLineDto"/> object to a <see cref="ResearchLineEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateResearchLineDto"/> object to convert.</param>
        /// <returns>A new <see cref="ResearchLineEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ResearchLineEntity ToEntity(this CreateResearchLineDto self) =>
            self is null ? new ResearchLineEntity() : new ResearchLineEntity
            {
                Name = self.Name,
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ResearchLineEntity"/> object using the values from a <see cref="CreateResearchLineDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateResearchLineDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ResearchLineEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ResearchLineEntity"/> object.</returns>
        public static ResearchLineEntity ToEntity(this CreateResearchLineDto self, ResearchLineEntity entityToUpdate)
        {
            entityToUpdate.Name = self.Name;
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="ResearchLineEntity"/> object to a <see cref="ResearchLineDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ResearchLineEntity"/> object to convert.</param>
        /// <returns>A new <see cref="ResearchLineDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ResearchLineDto ToDto(this ResearchLineEntity self) =>
            self is null ? new ResearchLineDto() : new ResearchLineDto
            {
                Id = self.Id,
                Name = self.Name,
                Projects = self.Projects.Select(p => p.ToDto()).ToList(),
            };
    }
}
