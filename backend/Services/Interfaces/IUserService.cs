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
        /// Authenticate user with provided email and password
        /// </summary>
        /// <param name="loginDto">The LoginDto object containing email and password information</param>
        /// <returns>The generated JWT token</returns>
        Task<LoginResultDto> AuthenticateAsync(LoginDto loginDto);
    }
}
