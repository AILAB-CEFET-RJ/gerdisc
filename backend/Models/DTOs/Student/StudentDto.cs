using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.DTOs
{
    public class StudentDto : UserDto
    {
        public string? Registration { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [Required(ErrorMessage = "ProjectId is required")]
        public Guid ProjectId { get; set; }

        public int Status { get; set; }

        public DateTime? EntryDate { get; set; }

        public DateTime? ProjectDefenceDate { get; set; }

        public DateTime? ProjectQualificationDate { get; set; }

        public string? Proficiency { get; set; }

        public string? UndergraduateInstitution { get; set; }

        public int InstitutionType { get; set; }

        public string? UndergraduateCourse { get; set; }

        public int GraduationYear { get; set; }

        public int UndergraduateArea { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int Scholarship { get; set; }

        public IEnumerable<StudentCourseDto>? StudentCourses { get; set; }

        public StudentDto()
        {
            Role = Enums.RolesEnum.Student;
        }
    }
}