using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Services.Interfaces
{
    /// <summary>
    /// provides the contract for user-related operations in the application.
    /// It defines several methods for creating, retrieving, updating, and deleting user information.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user entity.
        /// </summary>
        /// <param name="userDto">The user entity to create.</param>
        /// <returns>The created user entity.</returns>
        Task<UserEntity> CreateUserAsync(UserDto userDto);

        /// <summary>
        /// Authenticate user with provided email and password
        /// </summary>
        /// <param name="loginDto">The LoginDto object containing email and password information</param>
        /// <returns>The generated JWT token</returns>
        Task<LoginResultDto> AuthenticateAsync(LoginDto loginDto);
    }
}
