using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerdisc.DTOs;
using gerdisc.Entities;

namespace gerdisc.Mapper
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