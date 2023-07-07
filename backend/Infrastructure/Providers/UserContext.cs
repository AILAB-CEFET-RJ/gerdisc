using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Providers
{
    public class UserContext : IUserContext
    {
        /// <inheritdoc />
        public Guid? UserId { get; set; }

        /// <inheritdoc />
        public RolesEnum? Role { get; set; }
    }
}