using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gerdisc.Models.DTOs
{
    public class ProjectDto
    {
        public Guid? Id { get; set; }
        public Guid ResearchLineId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        [BindNever]
        public List<UserDto> Professors { get; set; }
        [BindNever]
        public List<StudentDto> Students { get; set; }
        public List<OrientationDto> Orientations { get; set; }

        public ProjectDto()
        {
            Professors = new List<UserDto>();
            Students = new List<StudentDto>();
            Orientations = new List<OrientationDto>();
        }
    }
}
