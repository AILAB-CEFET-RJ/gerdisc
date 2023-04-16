namespace gerdisc.Models.DTOs
{
    public record CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Credits { get; set; }

        public string? Code { get; set; }

        public bool IsElective { get; set; }

        public string? Concept { get; set; }
    }
}
