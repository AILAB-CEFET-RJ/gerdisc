using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents an external researcher in the system.
    /// </summary>
    public record ExternalResearcherEntity : BaseEntity
    {
        /// <summary>
        /// The user ID of the external researcher.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// a string representing the name of the institution that the external researcher is affiliated with.
        /// </summary>
        public string? Institution { get; set; }
    }
}