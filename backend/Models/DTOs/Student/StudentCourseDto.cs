namespace gerdisc.Models.DTOs
{
    public class StudentCourseDto
    {
        public Guid StudentId { get; set; }

        public virtual StudentDto? Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual CourseDto? Course { get; set; }

        public char Grade { get; set; }

        public int Year { get; set; }

        public int Trimester { get; set; }
    }
}
