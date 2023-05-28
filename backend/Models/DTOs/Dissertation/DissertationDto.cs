using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class DissertationDto
    {
        public Guid? Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; } = "";
        public Guid ProjectId { get; set; }
    }
}