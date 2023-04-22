using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Properties;

namespace gerdisc.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly ISigningConfiguration _singingConfig;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IRepository repository,
            ISigningConfiguration singingConfig,
            ILogger<UserService> logger
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _singingConfig = singingConfig ?? throw new ArgumentNullException(nameof(singingConfig));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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