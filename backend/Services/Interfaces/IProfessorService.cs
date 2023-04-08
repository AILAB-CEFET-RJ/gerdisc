using gerdisc.Models.DTOs;

namespace gerdisc.Services.Professor
{
    /// <summary>
    /// Defines methods for managing professors.
    /// </summary>
    public interface IProfessorService
    {
        /// <summary>
        /// Creates a new professor.
        /// </summary>
        /// <param name="professorDto">The professor DTO containing the professor details.</param>
        /// <returns>The created professor DTO.</returns>
        Task<ProfessorDto> CreateProfessorAsync(ProfessorDto professorDto);

        /// <summary>
        /// Retrieves a professor by ID.
        /// </summary>
        /// <param name="id">The ID of the professor to retrieve.</param>
        /// <returns>The professor DTO with the specified ID.</returns>
        Task<ProfessorDto> GetProfessorAsync(int id);

        /// <summary>
        /// Gets a list of all professor entities.
        /// </summary>
        /// <returns>A list of all professor entities.</returns>
        Task<IEnumerable<ProfessorDto>> GetAllProfessorsAsync();

        /// <summary>
        /// Updates a professor.
        /// </summary>
        /// <param name="id">The ID of the professor to update.</param>
        /// <param name="professorDto">The professor DTO containing the updated professor details.</param>
        /// <returns>The updated professor DTO.</returns>
        Task<ProfessorDto> UpdateProfessorAsync(int id, ProfessorDto professorDto);

        /// <summary>
        /// Deletes a professor.
        /// </summary>
        /// <param name="id">The ID of the professor to delete.</param>
        Task DeleteProfessorAsync(int id);
    }
}
