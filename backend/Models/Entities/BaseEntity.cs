using System.ComponentModel.DataAnnotations;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents the base entity for all entities in the system.
    /// </summary>
    public record BaseEntity
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}