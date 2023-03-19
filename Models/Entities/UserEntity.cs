using gerdisc.Models.Enums;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a user in the Database.
    /// </summary>
    public record UserEntity : BaseEntity
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; init; }

        public string? PasswordHash { get; set; }

        public RolesEnum Role { get; set; }

        public DateTime CreatedAt { get; init; }
    }
}