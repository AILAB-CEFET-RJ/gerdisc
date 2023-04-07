using gerdisc.Models.DTOs;

namespace gerdisc.Services.Dissertation
{
    /// <summary>
    /// Defines methods for managing dissertations.
    /// </summary>
    public interface IDissertationService
    {
        /// <summary>
        /// Creates a new dissertation.
        /// </summary>
        /// <param name="dissertationDto">The dissertation DTO containing the dissertation details.</param>
        /// <returns>The created dissertation DTO.</returns>
        Task<DissertationDto> CreateDissertationAsync(DissertationDto dissertationDto);

        /// <summary>
        /// Retrieves a dissertation by ID.
        /// </summary>
        /// <param name="id">The ID of the dissertation to retrieve.</param>
        /// <returns>The dissertation DTO with the specified ID.</returns>
        Task<DissertationDto> GetDissertationAsync(int id);

        /// <summary>
        /// Updates a dissertation.
        /// </summary>
        /// <param name="id">The ID of the dissertation to update.</param>
        /// <param name="dissertationDto">The dissertation DTO containing the updated dissertation details.</param>
        /// <returns>The updated dissertation DTO.</returns>
        Task<DissertationDto> UpdateDissertationAsync(int id, DissertationDto dissertationDto);

        /// <summary>
        /// Deletes a dissertation.
        /// </summary>
        /// <param name="id">The ID of the dissertation to delete.</param>
        Task DeleteDissertationAsync(int id);
    }
}
