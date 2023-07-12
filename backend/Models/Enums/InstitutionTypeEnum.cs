using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.Enums
{
    public enum InstitutionTypeEnum
    {
        Default,
        [Name("PUBLICA")]
        Publica,
        [Name("PARTICULAR")]
        Particular,
        [Name("CEFET/RJ")]
        CEFET
    }
}