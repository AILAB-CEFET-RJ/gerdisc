using System.ComponentModel.DataAnnotations;
using gerdisc.Infrastructure.Validations;
using gerdisc.Models.Enums;

namespace gerdisc.Models.DTOs
{
    public class ExternalResearcherDto : UserDto
    {
        [Required]
        [StringLength(20)]
        public string? Institution { get; set; }

        [ValidRolesEnum(RolesEnum.ExternalResearcher)]
        public override RolesEnum Role { get; set; }

        public ExternalResearcherDto()
        {
            Role = Enums.RolesEnum.ExternalResearcher;
        }
    }
}
