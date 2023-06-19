using System.ComponentModel.DataAnnotations.Schema;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents the orientation of a professor or external researcher in a student's dissertation project.
    /// </summary>
    public record OrientationEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the professor.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="UserEntity"/> entity.
        /// </remarks>
        public Guid CoorientatorId { get; set; }

        /// <summary>
        /// Gets or sets the professor navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="UserEntity"/> entity.
        /// </remarks>
        [ForeignKey("CoorientatorId")]
        public virtual UserEntity? Coorientator { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the dissertation.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="DissertationEntity"/> entity.
        /// </remarks>
        public Guid DissertationId { get; set; }

        /// <summary>
        /// Gets or sets the dissertation navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="DissertationEntity"/> entity.
        /// </remarks>
        public virtual DissertationEntity? Dissertation { get; set; }
    }
}
