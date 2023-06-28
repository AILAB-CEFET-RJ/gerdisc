using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class ExtensionDto
    {
        public Guid? Id { get; set; }

        public Guid StudentId { get; set; }

        public int NumberOfDays { get; set; }

        public string? Status { get; set; }

        public ExtensionTypeEnum Type { get; set; }
    }
}
