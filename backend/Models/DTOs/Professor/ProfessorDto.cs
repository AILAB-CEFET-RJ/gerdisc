using gerdisc.Infrastructure.Validations;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class ProfessorDto : UserDto
    {
        public string? Siape { get; set; }
        [ValidRolesEnum(RolesEnum.Administrator, RolesEnum.Professor)]
        public override RolesEnum Role { get; set; }

        public ProfessorDto()
        {
            Role = Enums.RolesEnum.Professor;
        }
    }
}