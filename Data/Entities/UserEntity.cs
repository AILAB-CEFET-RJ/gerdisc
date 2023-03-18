using gerdisc.Data.Enums;

namespace gerdisc.Data.Entities
{
    /// <summary>
    /// Represents a user in the database.
    /// </summary>
    public record UserEntity : BaseEntity
    {
        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        public string? Email { get; init; }

        public string? PasswordHash { get; init; }

        public RolesEnum Role { get; set; }

        public DateTime CreatedAt { get; init; }
    }
}