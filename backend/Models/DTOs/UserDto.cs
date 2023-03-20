using System;
using System.ComponentModel.DataAnnotations;
using gerdisc.Models.Enums;
using gerdisc.Models.Validations;

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

        [Required(ErrorMessage = "Email is required")]
        [ValidEmail(ErrorMessage = "Email is not in a valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public RolesEnum Role { get; set; }
    }
}