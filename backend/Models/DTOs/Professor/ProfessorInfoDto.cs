using gerdisc.Infrastructure.Validations;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class ProfessorInfoDto : UserDto
    {
        public string? Siape { get; set; }
        [ValidRolesEnum(RolesEnum.Administrator, RolesEnum.Professor)]
        public override RolesEnum Role { get; set; }

        public ProfessorInfoDto()
        {
            Role = Enums.RolesEnum.Professor;
        }
    }
}