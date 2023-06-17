using gerdisc.Models.Enums;

public interface IUserContext
{
    Guid UserId { get; set; }
    RolesEnum Role { get; set; }
}
