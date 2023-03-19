using gerdisc.Models.DTOs;

namespace gerdisc.Services.User
{
    /// <summary>
    /// provides the contract for user-related operations in the application.
    /// It defines several methods for creating, retrieving, updating, and deleting user information.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="userDto">The UserDto object containing user information</param>
        /// <returns>The newly created UserDto object</returns>
        Task<UserDto> CreateUserAsync(UserDto userDto);

        /// <summary>
        /// Authenticate user with provided email and password
        /// </summary>
        /// <param name="loginDto">The LoginDto object containing email and password information</param>
        /// <returns>The generated JWT token</returns>
        Task<string> AuthenticateAsync(LoginDto loginDto);

        /// <summary>
        /// Retrieve user information by user id
        /// </summary>
        /// <param name="id">The user id</param>
        /// <returns>The UserDto object containing user information</returns>
        Task<UserDto> GetUserAsync(int id);

        /// <summary>
        /// Update user information by user id
        /// </summary>
        /// <param name="id">The user id</param>
        /// <param name="userDto">The UserDto object containing updated user information</param>
        /// <returns>The updated UserDto object</returns>
        Task<UserDto> UpdateUserAsync(int id, UserDto userDto);

        /// <summary>
        /// Delete user by user id
        /// </summary>
        /// <param name="id">The user id</param>
        Task DeleteUserAsync(int id);
    }
}
