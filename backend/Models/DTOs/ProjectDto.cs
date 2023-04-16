namespace gerdisc.Models.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<ProfessorDto> Professors { get; set; }
        public List<StudentDto> Students { get; set; }
        public List<DissertationDto> Dissertations { get; set; }
    }
}
