using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class ProfessorDto : UserDto
    {
        public string? Siape { get; set; }
        public ProfessorDto()
        {
            Role = Enums.RolesEnum.Professor;
        }
    }
}