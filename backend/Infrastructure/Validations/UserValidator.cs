using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;

namespace gerdisc.Infrastructure.Validations
{
    /// <summary>
    /// Provides validation methods for users.
    /// </summary>
    public class UserValidator
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class.
        /// </summary>
        /// <param name="repository">The repository used for data access.</param>
        public UserValidator(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Checks if a user can be added based on the provided user DTO.
        /// </summary>
        /// <param name="userDto">The user DTO to be checked.</param>
        /// <returns>A tuple containing a boolean indicating if the user can be added and an error message if applicable.</returns>
        public async Task<(bool exists, string errorMessage)> CanAddUser(UserDto userDto)
        {
            if (userDto is null || userDto.Email is null)
            {
                return (false, $"Invalid user DTO.");
            }

            var user = await _repository.User.GetUserByEmail(userDto.Email);

            if (user is not null)
            {
                return (false, $"User with email '{userDto.Email}' already exists.");
            }

            return (true, "Success");
        }
    }
}
