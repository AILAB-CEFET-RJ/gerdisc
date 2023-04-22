using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.DTOs
{
    public class ExternalResearcherDto
    {
        public Guid? Id { get; set; }
        public UserDto User { get; set; }

        [Required]
        [StringLength(20)]
        public string? Institution { get; set; }
    }
}
