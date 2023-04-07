using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.DTOs
{
    public class ExternalResearcherDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string? Institution { get; set; }
    }
}
