using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gerdisc.Infrastructure.Validations;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class CreateProfessorDto : UserDto
    {
        public string? Siape { get; set; }
        public List<string> ProjectIds { get; set; }

        [ValidRolesEnum(RolesEnum.Administrator, RolesEnum.Professor)]
        public override RolesEnum Role { get; set; }

        public CreateProfessorDto()
        {
            Role = Enums.RolesEnum.Professor;
            ProjectIds = new List<string>();
        }
    }
}