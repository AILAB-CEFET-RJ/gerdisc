using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class OrientationDto : CreateOrientationDto
    {
        public Guid Id { get; set; }

        public virtual UserDto? Coorientator { get; set; }

        public virtual UserDto? Student { get; set; }

        public virtual ProjectDto? Project { get; set; }

        public virtual UserDto? Professor { get; set; }

        public OrientationDto()
        {
        }
    }
}