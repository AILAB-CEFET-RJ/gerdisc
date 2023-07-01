using gerdisc.Infrastructure.Providers;
using gerdisc.Infrastructure.Providers.Interfaces;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Infrastructure.Validations;
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
        private readonly ITokenProvider _tokenProvider;
        private readonly ILogger<UserService> _logger;
        private readonly UserValidator _userValidator;
        public UserService(
            IRepository repository,
            ITokenProvider tokenProvider,
            ILogger<UserService> logger,
            IEmailSender emailSender,
            UserValidator userValidator
        )
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _userValidator= userValidator?? throw new ArgumentNullException(nameof(userValidator));
        }

        /// <inheritdoc />
        public async Task<UserEntity> CreateUserAsync(UserDto userDto)
        {
            (var isValid, var message) = await _userValidator.CanAddUser(userDto);
            _logger.LogInformation($"Creating user{userDto.Email}");
            if (!isValid)
            {
                throw new ArgumentException(message);
            }
            var user = await _repository.User.AddAsync(userDto.ToUserEntity());
            var token = _tokenProvider.GenerateResetPasswordJwt(user, TimeSpan.FromDays(7));
            string emailSubject = "User Account Created";
            string emailBody = $"Thank you for creating an account! Your temporary password is: {token}. Please change your password after logging in.";
            await _emailSender.SendEmail(userDto.Email, emailSubject, emailBody).ConfigureAwait(false);
            return user;
        }

        /// <inheritdoc />
        public async Task ResetPasswordRequestAsync(RequestResetPasswordDto request)
        {
            var user = await _repository.User.GetUserByEmail(request.Email) ?? throw new ArgumentException($"User with email {request.Email} not found.");

            var token = _tokenProvider.GenerateResetPasswordJwt(user, TimeSpan.FromMinutes(30));
            string emailSubject = "Password Reset";
            string emailBody = $"You have requested to reset your password. Please click on the following link to reset your password: {token}";
            await _emailSender.SendEmail(request.Email, emailSubject, emailBody).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<LoginResultDto> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            (var isValid, var message) = await _userValidator.CanResetPassword(resetPasswordDto);
            _logger.LogInformation($"Changing password of user: {resetPasswordDto.Email}");
            if (!isValid)
            {
                throw new ArgumentException(message);
            }

            var user = await _repository.User.GetUserByEmail(resetPasswordDto.Email.ToLower()) ?? throw new ArgumentException($"User with email {resetPasswordDto.Email} not found.");
            user.PasswordHash = HashPassword(resetPasswordDto.Password);

            await _repository.User.UpdateAsync(user);

            var jwtToken = _tokenProvider.GenerateJwtToken(user);

            return user.ToDto(jwtToken);
        }


        /// <inheritdoc />
        public async Task<LoginResultDto> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _repository.User.GetUserByEmail(loginDto.Email.ToLower());
            if (user == null)
            {
                throw new ArgumentException($"User with email {loginDto.Email} not found.");
            }

            if (!VerifyPassword(loginDto.Password ?? "", user.PasswordHash ?? ""))
            {
                throw new ArgumentException("Invalid password.");
            }

            return user.ToDto(_tokenProvider.GenerateJwtToken(user));
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