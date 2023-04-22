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
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [ValidEmail(ErrorMessage = "Email is not in a valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Cpf { get; set; }

        public DateTime CreatedAt { get; set; }

        public RolesEnum Role { get; set; }
    }
}