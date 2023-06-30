using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.DTOs
{
    public class StudentCourseCsvDto
    {
        [Name("MATR_ALUNO")]
        public string StudentRegistration { get; set; }

        [Name("NOME_DISCIPLINA")]
        public string CourseName { get; set; }

        [Name("CONCEITO")]
        public char Grade { get; set; }

        [Name("ANO")]
        public int Year { get; set; }

        [Name("PERIODO")]
        public string Trimester { get; set; }
    }
}
