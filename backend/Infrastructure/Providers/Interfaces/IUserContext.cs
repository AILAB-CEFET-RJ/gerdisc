using gerdisc.Models.Enums;

namespace gerdisc.Infrastructure.Providers
{
    public interface IUserContext
    {
        Guid? UserId { get; set; }
        RolesEnum? Role { get; set; }
    }
}