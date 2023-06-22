using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.DTOs
{
    public class StudentCsvDto
    {
	    [Name("Nome")]
        public string? Name { get; set; }

	    [Name("E-mail")]
        public string? Email { get; set; }

	    [Name("CPF")]
        public string? Cpf { get; set; }

	    [Name("Inscrição")]
        public string? Registration { get; set; }

        public string? RegistrationDate { get; set; }

        public string? ProjectId { get; set; }

        public int Status { get; set; }

        public string? EntryDate { get; set; }

        public string? ProjectDefenceDate { get; set; }

        public string? ProjectQualificationDate { get; set; }

        public string? Proficiency { get; set; }

        public string? CPF { get; set; }

        public string? UndergraduateInstitution { get; set; }

        public int InstitutionType { get; set; }

        public string? UndergraduateCourse { get; set; }

        public int GraduationYear { get; set; }

        public int UndergraduateArea { get; set; }

	    [Name("Nascimento")]
        public string? DateOfBirth { get; set; }

        public int Scholarship { get; set; }
    }
}
