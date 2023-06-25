using CsvHelper.Configuration.Attributes;
using gerdisc.Models.Enums;

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

        [Optional]
        public string? RegistrationDate { get; set; }

        [Optional]
        public string? ProjectId { get; set; }

        [Optional]
        public StatusEnum Status { get; set; }

        [Optional]
        public string? EntryDate { get; set; }

        [Optional]
        public string? ProjectDefenceDate { get; set; }

        [Optional]
        public string? ProjectQualificationDate { get; set; }

        [Optional]
        public string? Proficiency { get; set; }

	    [Name("Instituição de Formação")]
        public string? UndergraduateInstitution { get; set; }

        [Optional]
        public InstitutionTypeEnum InstitutionType { get; set; }

	    [Name("Curso")]
        public string? UndergraduateCourse { get; set; }

	    [Name("Ano de Formação")]
        public int GraduationYear { get; set; }

        [Optional]
        public UndergraduateAreaEnum UndergraduateArea { get; set; }

	    [Name("Nascimento")]
        public string? DateOfBirth { get; set; }

        [Optional]
        public int Scholarship { get; set; }
    }
}
