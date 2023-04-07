using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class DissertationDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Name { get; set; }
        public int ProjectId { get; set; }
    }
}