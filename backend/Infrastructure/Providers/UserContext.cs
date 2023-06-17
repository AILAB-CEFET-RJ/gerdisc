using gerdisc.Models.Enums;

public class UserContext : IUserContext
{
    public Guid? UserId { get; set; }
    public RolesEnum? Role { get; set; }
}