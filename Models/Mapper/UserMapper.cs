using gerdisc.Models.DTOs;
using gerdisc.Models.Entities;

namespace gerdisc.Models.Mapper
{
    public static class UserMapper
    {
        public static UserEntity Map(this UserDto self, string password) =>
            new UserEntity
            {
                Id = self.Id,
                FirstName = self.FirstName,
                LastName = self.LastName,
                Email = self.Email,
                CreatedAt = self.CreatedAt,
                PasswordHash = password
            };

        public static UserDto Map(this UserEntity self) =>
            new UserDto
            {
                Id = self.Id,
                FirstName = self.FirstName,
                LastName = self.LastName,
                Email = self.Email,
                CreatedAt = self.CreatedAt
            };
    }
}