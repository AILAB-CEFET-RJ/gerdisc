using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Properties;
using gerdisc.Models.Mapper;

namespace gerdisc.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly ISingingConfiguration _singingConfig;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IRepository repository,
            ISingingConfiguration singingConfig,
            ILogger<UserService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _singingConfig = singingConfig ?? throw new ArgumentNullException(nameof(singingConfig));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var count = await _repository.User.CountAsync();
            userDto.Id = count + 1;

            var passwordHash = HashPassword(userDto.Password);
            var user = userDto.ToEntity(passwordHash);

            await _repository.User.AddAsync(user);
            await _repository.User.CommitAsync();

            _logger.LogInformation($"User {user.Email} created successfully.");
            return userDto;
        }

        public async Task<string> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _repository.User.GetUserByEmail(loginDto.Email);
            if (user == null)
            {
                throw new ArgumentException($"User with email {loginDto.Email} not found.");
            }

            if (!VerifyPassword(loginDto.Password??"", user.PasswordHash??""))
            {
                throw new ArgumentException("Invalid password.");
            }

            return user.GenerateJwtToken(_singingConfig.Key);
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var userEntity = await _repository.User.GetSingleAsync(id);
            if (userEntity == null)
            {
                throw new ArgumentException("User not found.");
            }

            return userEntity.ToDto();
        }

        public async Task<UserDto> UpdateUserAsync(int id, UserDto userDto)
        {
            var existingUser = await _repository.User.GetSingleAsync(id);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with id {id} does not exist.");
            }

            existingUser = userDto.ToEntity(existingUser);

            await _repository.User.CommitAsync();

            return existingUser.ToDto();
        }

        public async Task DeleteUserAsync(int id)
        {
            var existingUser = await _repository.User.GetSingleAsync(id);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with id {id} does not exist.");
            }

            _repository.User.Delete(existingUser);
            await _repository.User.CommitAsync();
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}