using gerdisc.Infrastructure.Validations;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class ProfessorDto : UserDto
    {
        public string? Siape { get; set; }
        public List<ProjectDto> Projects { get; set; }

        [ValidRolesEnum(RolesEnum.Administrator, RolesEnum.Professor)]
        public override RolesEnum Role { get; set; }

        public ProfessorDto()
        {
            Role = Enums.RolesEnum.Professor;
            Projects = new List<ProjectDto>();
        }
    }
}