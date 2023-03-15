using gerdisc.Mapper;
using gerdisc.Repositories;
using gerdisc.DTOs;
using gerdisc.Data.DTOs;
using gerdisc.Core.Services;
using System.Security.Cryptography;
using gerdisc.Propierties;

namespace gerdisc.Core
{
    public class UserOperation
    {
        public IUnitOfWork UnitOfWork { get; set; }
        private ISingingConfiguration _singingConfig { get; }
        public UserOperation(
            IUnitOfWork unitOfWork,
            ISingingConfiguration singingConfig
        )
        {
            UnitOfWork = unitOfWork;
            _singingConfig = singingConfig;
        }

        public void CreateUser(UserDto user)
        {
            user.Id = UnitOfWork.User.Count()+1;
            UnitOfWork.User.Add(user.Map(BCrypt.Net.BCrypt.HashPassword("12345678")));
            UnitOfWork.User.Commit();
        }

        public string? Login(LoginDto login)
        {
            var user = UnitOfWork.User.GetSingle(x => x.Email == login.Email);
            bool verified = BCrypt.Net.BCrypt.Verify(login.Password, user?.PasswordHash);
            if (!verified)
            {
                return null;
            }
            return user?.GenerateJwtToken(_singingConfig.Key);
        }
    }
}