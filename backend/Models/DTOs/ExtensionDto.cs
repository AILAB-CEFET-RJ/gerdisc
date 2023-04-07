using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gerdisc.Models.DTOs
{
    public class ExtensionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public List<int> ProfessorIds { get; set; }
        public List<int> StudentIds { get; set; }
        public List<int> DissertationIds { get; set; }
    }
}