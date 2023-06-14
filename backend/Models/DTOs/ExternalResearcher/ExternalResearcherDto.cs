using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.DTOs
{
    public class ExternalResearcherDto : UserDto
    {
        [Required]
        [StringLength(20)]
        public string? Institution { get; set; }

        public ExternalResearcherDto()
        {
            Role = Enums.RolesEnum.ExternalResearcher;
        }
    }
}
