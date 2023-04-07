using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    /// <summary>
    /// A static class containing mapper methods for converting between <see cref="ProjectDto"/> and <see cref="ProjectEntity"/> objects.
    /// </summary>
    public static class ProjectMapper
    {
        /// <summary>
        /// Converts a <see cref="ProjectDto"/> object to a <see cref="ProjectEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProjectDto"/> object to convert.</param>
        /// <returns>A new <see cref="ProjectEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProjectEntity ToEntity(this ProjectDto self) =>
            self is null ? new ProjectEntity() : new ProjectEntity
            {
                Id = self.Id,
                Name = self.Name,
                Status = self.Status,
                Professors = self.Professors?.Select(p => p.ToEntity()).ToList(),
                Students = self.Students?.Select(s => s.ToEntity()).ToList(),
                Dissertations = self.Dissertations?.Select(d => d.ToEntity()).ToList()
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ProjectEntity"/> object using the values from a <see cref="ProjectDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProjectDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ProjectEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ProjectEntity"/> object.</returns>
        public static ProjectEntity ToEntity(this ProjectDto self, ProjectEntity entityToUpdate)
        {
            entityToUpdate.Name = self.Name;
            entityToUpdate.Status = self.Status;
            entityToUpdate.Professors = self.Professors?.Select(p => p.ToEntity()).ToList();
            entityToUpdate.Students = self.Students?.Select(s => s.ToEntity()).ToList();
            entityToUpdate.Dissertations = self.Dissertations?.Select(d => d.ToEntity()).ToList();
            return entityToUpdate;
        }

        /// <summary>
        /// Converts a <see cref="ProjectEntity"/> object to a <see cref="ProjectDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="ProjectEntity"/> object to convert.</param>
        /// <returns>A new <see cref="ProjectDto"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProjectDto ToDto(this ProjectEntity self) =>
            self is null ? new ProjectDto() : new ProjectDto
            {
                Id = self.Id,
                Name = self.Name,
                Status = self.Status,
                Professors = self.Professors?.Select(p => p.ToDto()).ToList(),
                Students = self.Students?.Select(s => s.ToDto()).ToList(),
                Dissertations = self.Dissertations?.Select(d => d.ToDto()).ToList()
            };
    }
}
