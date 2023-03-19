using System;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    /// <summary>
    /// Represents a user cantract to the api.
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public RolesEnum Role { get; set; }
    }
}