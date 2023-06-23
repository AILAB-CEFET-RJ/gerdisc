using gerdisc.Models.DTOs;

namespace gerdisc.Services.Interfaces
{
    /// <summary>
    /// Defines methods for managing orientations.
    /// </summary>
    public interface IOrientationService
    {
        /// <summary>
        /// Creates a new orientation.
        /// </summary>
        /// <param name="orientationDto">The orientation DTO containing the orientation details.</param>
        /// <returns>The created orientation DTO.</returns>
        Task<OrientationDto> CreateOrientationAsync(CreateOrientationDto orientationDto);

        /// <summary>
        /// Retrieves a orientation by ID.
        /// </summary>
        /// <param name="id">The ID of the orientation to retrieve.</param>
        /// <returns>The orientation DTO with the specified ID.</returns>
        Task<OrientationDto> GetOrientationAsync(Guid id);

        /// <summary>
        /// Gets a list of all orientation entities.
        /// </summary>
        /// <returns>A list of all orientation entities.</returns>
        Task<IEnumerable<OrientationDto>> GetAllOrientationsAsync();

        /// <summary>
        /// Updates a orientation.
        /// </summary>
        /// <param name="id">The ID of the orientation to update.</param>
        /// <param name="orientationDto">The orientation DTO containing the updated orientation details.</param>
        /// <returns>The updated orientation DTO.</returns>
        Task<OrientationDto> UpdateOrientationAsync(Guid id, CreateOrientationDto orientationDto);

        /// <summary>
        /// Deletes a orientation.
        /// </summary>
        /// <param name="id">The ID of the orientation to delete.</param>
        Task DeleteOrientationAsync(Guid id);
    }
}
