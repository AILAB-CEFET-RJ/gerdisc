using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.DTOs
{
    public class StudentCsvDto
    {
	    [Name("Nome")]
        public string? Name { get; set; }

	    [Name("Email")]
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

	    [Name("Instituição de Formação")]
        public string? UndergraduateInstitution { get; set; }

        public int InstitutionType { get; set; }

	    [Name("Curso")]
        public string? UndergraduateCourse { get; set; }

	    [Name("Ano de Formação")]
        public int GraduationYear { get; set; }

        public int UndergraduateArea { get; set; }

	    [Name("Nascimento")]
        public string? DateOfBirth { get; set; }

        public int Scholarship { get; set; }
    }
}
