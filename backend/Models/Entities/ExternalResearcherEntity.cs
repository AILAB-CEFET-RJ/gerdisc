using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.Entities
{
    public record ExternalResearcherEntity : BaseEntity
    {
        /// <summary>
        /// The user ID of the externalResearcher.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The SIAPE (System for Electronic Management of Educational Documentation) number of the externalResearcher.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string? Siape { get; set; }
    }
}