using CsvHelper.Configuration.Attributes;

namespace gerdisc.Models.Enums
{
    public enum ScholarshipEnum
    {
        Default,
        [Name("CEFET")]
        Cefet,
        [Name("CAPES")]
        Capes,
        [Name("FAPE/RJ")]
        FapeRj
    }
}