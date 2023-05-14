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
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the associated user entity.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the associated <see cref="UserEntity"/> entity.
        /// </remarks>
        public virtual UserEntity User { get; set; }

        /// <summary>
        /// a string representing the name of the institution that the external researcher is affiliated with.
        /// </summary>
        public string? Institution { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalResearcherEntity"/> class with the specified properties.
        /// </summary>
        public ExternalResearcherEntity()
        {
            User = new UserEntity();
        }
    }
}