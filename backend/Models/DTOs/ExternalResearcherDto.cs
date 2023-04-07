using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.DTOs
{
    public class ExternalResearcherDTO
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string? Institution { get; set; }
    }
}
