using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class CreateProjectDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public List<string> ProfessorIds { get; set; }
    }
}
