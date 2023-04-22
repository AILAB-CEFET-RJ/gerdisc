using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class ProfessorDto
    {
        public Guid? Id { get; set; }
        public UserDto User { get; set; }
        public string Siape { get; set; }
    }
}