using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class CreateProjectDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid ResearchLineId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public List<string> ProfessorIds { get; set; }
        public CreateProjectDto()
        {
            ProfessorIds = new List<string>();
        }
    }
}
