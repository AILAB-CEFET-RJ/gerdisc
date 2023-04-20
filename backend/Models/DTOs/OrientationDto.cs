using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class OrientationDto
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public int ResearcherId { get; set; }
        public DissertationDto Dissertation { get; set; }

        public OrientationDto()
        {
            Dissertation = new DissertationDto();
        }
    }
}