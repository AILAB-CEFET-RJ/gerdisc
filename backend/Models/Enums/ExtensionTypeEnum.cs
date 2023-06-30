using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.Enums
{
    public enum ExtensionTypeEnum
    {
        Default,
        [Name("Defesa")]
        Defence,
        [Name("Qualificação")]
        Qualification
    }
}