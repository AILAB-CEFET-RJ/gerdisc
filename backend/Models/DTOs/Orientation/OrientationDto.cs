using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class OrientationDto
    {
        public Guid Id { get; set; }

        public Guid? CoorientatorId { get; set; }

        public virtual UserDto? Coorientator { get; set; }

        public Guid StudentId { get; set; }

        public string? Dissertation { get; set; }

        public Guid ProjectId { get; set; }

        public virtual UserDto? Student { get; set; }

        public virtual ProjectDto? Project { get; set; }

        public Guid ProfessorId { get; set; }

        public virtual UserDto? Professor { get; set; }

        public OrientationDto()
        {
        }
    }
}