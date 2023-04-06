using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Services.Interfaces
{
    /// <summary>
    /// Provides CRUD operations for managing student entities.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Creates a new student entity.
        /// </summary>
        /// <param name="studentDto">The student entity to create.</param>
        /// <returns>The created student entity.</returns>
        Task<StudentDto> CreateStudentAsync(StudentDto student);

        /// <summary>
        /// Gets a student entity by its ID.
        /// </summary>
        /// <param name="studentId">The ID of the student entity to retrieve.</param>
        /// <returns>The student entity with the specified ID.</returns>
        Task<StudentDto> GetStudentAsync(int studentId);

        /// <summary>
        /// Update a student.
        /// </summary>
        /// <param name="id">The id of the student to update.</param>
        /// <param name="studentDto">The student DTO to update.</param>
        /// <returns>The updated student DTO.</returns>
        public Task<StudentDto> UpdateStudentAsync(int id, StudentDto studentDto);

        /// <summary>
        /// Deletes a student entity.
        /// </summary>
        /// <param name="studentId">The ID of the student entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteStudentAsync(int studentId);

        /// <summary>
        /// Gets a list of all student entities.
        /// </summary>
        /// <returns>A list of all student entities.</returns>
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    }
}
