using gerdisc.Models.Mapper;
using gerdisc.Infrastructure.Repositories;
using gerdisc.Models.DTOs;
using gerdisc.Propierties;

namespace gerdisc.Services
{
    public class UserOperation
    {
        public IRepository Repository { get; set; }
        private ISingingConfiguration _singingConfig { get; }
        public UserOperation(
            IRepository Repository,
            ISingingConfiguration singingConfig
        )
        {
            this.Repository = Repository;
            _singingConfig = singingConfig;
        }

        public void CreateUser(UserDto user)
        {
            user.Id = Repository.User.Count() + 1;
            Repository.User.Add(user.Map(BCrypt.Net.BCrypt.HashPassword("12345678")));
            Repository.User.Commit();
        }

        public string? Login(LoginDto login)
        {
            var user = Repository.User.GetSingle(x => x.Email == login.Email);
            bool verified = BCrypt.Net.BCrypt.Verify(login.Password, user?.PasswordHash);
            if (!verified)
            {
                return null;
            }
            return user?.GenerateJwtToken(_singingConfig.Key);
        }
    }
}