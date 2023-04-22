namespace gerdisc.Models.DTOs
{
    public class StudentDto
    {
        public Guid? Id { get; set; }
        public UserDto User { get; set; }

        public string? Registration { get; set; }
        
        public DateTime RegistrationDate { get; set; }
        
        public string? ProjectId { get; set; }
        
        public int Status { get; set; }
        
        public DateTime EntryDate { get; set; }
        
        public DateTime ProjectDefenceDate { get; set; }
        
        public DateTime ProjectQualificationDate { get; set; }
        
        public string? Proficiency { get; set; }
        
        public string? CPF { get; set; }
        
        public string? UndergraduateInstitution { get; set; }
        
        public int InstitutionType { get; set; }
        
        public string? UndergraduateCourse { get; set; }
        
        public int GraduationYear { get; set; }
        
        public int UndergraduateArea { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        public int Scholarship { get; set; }
    }
}