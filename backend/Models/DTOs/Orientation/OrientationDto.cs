using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class OrientationDto
    {
        public Guid? Id { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid CoorientatorId { get; set; }
        public DissertationDto Dissertation { get; set; }

        public OrientationDto()
        {
            Dissertation = new DissertationDto();
        }
    }
}