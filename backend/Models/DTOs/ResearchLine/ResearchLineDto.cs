using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class ResearchLineDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public List<ProjectDto> Projects { get; set; }

        public ResearchLineDto()
        {
            Projects = new List<ProjectDto>();
        }
    }
}
