using System.ComponentModel.DataAnnotations.Schema;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a Dissertation in the system.
    /// </summary>
    [Table("Dissertations")]
    public record DissertationEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the foreign key of the student that wrote the dissertation.
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Name of the dissertation.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the project associated with the dissertation.
        /// </summary>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the associated student entity.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the associated <see cref="UserEntity"/> entity.
        /// </remarks>
        [ForeignKey("StudentId")]
        public virtual UserEntity? Student { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the associated project entity.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the associated <see cref="ProjectEntity"/> entity.
        /// </remarks>
        public virtual ProjectEntity? Project { get; set; }
    }
}
