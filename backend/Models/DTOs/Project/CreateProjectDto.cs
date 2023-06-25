using System.ComponentModel.DataAnnotations;
using gerdisc.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class CreateProjectDto
    {
        [Required]
        public Guid ResearchLineId { get; set; }
        public string? Name { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public List<string> ProfessorIds { get; set; }
        public CreateProjectDto()
        {
            ProfessorIds = new List<string>();
        }
    }
}
