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
        /// Converts a <see cref="CreateProjectDto"/> object to a <see cref="ProjectEntity"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateProjectDto"/> object to convert.</param>
        /// <returns>A new <see cref="ProjectEntity"/> object with the values from the <paramref name="self"/> object.</returns>
        public static ProjectEntity ToEntity(this CreateProjectDto self) =>
            self is null ? new ProjectEntity() : new ProjectEntity
            {
                Name = self.Name,
                Status = self.Status
            };

        /// <summary>
        /// Updates the values of an existing <see cref="ProjectEntity"/> object using the values from a <see cref="CreateProjectDto"/> object.
        /// </summary>
        /// <param name="self">The <see cref="CreateProjectDto"/> object containing the updated values.</param>
        /// <param name="entityToUpdate">The existing <see cref="ProjectEntity"/> object to update.</param>
        /// <returns>The updated <see cref="ProjectEntity"/> object.</returns>
        public static ProjectEntity ToEntity(this CreateProjectDto self, ProjectEntity entityToUpdate)
        {
            entityToUpdate.Name = self.Name;
            entityToUpdate.Status = self.Status;
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
                Professors = self.ProfessorProjects.Select(p => p.Professor.ToUserDto()).ToList(),
                Students = self.Students.Select(s => s.ToDto()).ToList(),
                Dissertations = self.Dissertations.Select(d => d.ToDto()).ToList()
            };
    }
}
