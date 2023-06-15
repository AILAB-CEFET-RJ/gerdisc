using gerdisc.Infrastructure.Providers;
using gerdisc.Infrastructure.Providers.Interfaces;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;
using gerdisc.Models.Mapper;
using gerdisc.Properties;
using gerdisc.Services.Interfaces;

namespace gerdisc.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IEmailSender _emailSender;
        private readonly ISigningConfiguration _singingConfig;
        private readonly ILogger<UserService> _logger;

        public UserService(
            IRepository repository,
            ISigningConfiguration singingConfig,
            ILogger<UserService> logger,
            IEmailSender emailSender
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _singingConfig = singingConfig ?? throw new ArgumentNullException(nameof(singingConfig));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
        }

        public async Task<UserEntity> CreateUserAsync(UserDto userDto)
        {
            _logger.LogInformation($"Creating user{userDto.Email}");
            if (userDto == null || userDto.Email == null)
            {
                throw new ArgumentException("userDto.");
            }
            var user = await _repository.User.AddAsync(userDto.ToUserEntity());
            var token = user.GenerateResetPasswordJwt(_singingConfig.Key, DateTime.Now.AddDays(7));
            await _emailSender.SendEmail(userDto.Email, "Create user", $"Create an password: {token}");
            return user;
        }

        public async Task ResetPasswordRequestAsync(RequestResetPasswordDto request)
        {
            var user = await _repository
                .User
                .GetUserByEmail(request.Email) ?? throw new ArgumentException($"User with email {request.Email} not found.");
            var token = user.GenerateResetPasswordJwt(_singingConfig.Key, DateTime.Now.AddMinutes(30));
            await _emailSender.SendEmail(request.Email, "reset password", $"Reset your password with the link: {token} .");
        }

        public async Task<LoginResultDto> ResetPasswordAsync(ResetPasswordDto loginDto)
        {
            var user = await _repository
                .User
                .GetUserByEmail(loginDto.Email) ?? throw new ArgumentException($"User with email {loginDto.Email} not found.");
            user.PasswordHash = HashPassword(loginDto.Password);
            return user.ToDto(user.GenerateJwtToken(_singingConfig.Key));
        }

        public async Task<LoginResultDto> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _repository.User.GetUserByEmail(loginDto.Email);
            if (user == null)
            {
                throw new ArgumentException($"User with email {loginDto.Email} not found.");
            }

            if (!VerifyPassword(loginDto.Password ?? "", user.PasswordHash ?? ""))
            {
                throw new ArgumentException("Invalid password.");
            }

            return user.ToDto(user.GenerateJwtToken(_singingConfig.Key));
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