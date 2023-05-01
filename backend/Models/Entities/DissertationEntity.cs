namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a Dissertation in the system.
    /// </summary>
    public record DissertationEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the foreign key of the student that wrote the dissertation.
        /// </summary>
        public Guid StudentId { get; set; }

        /// <summary>
        /// Name of the dissertation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the project associated with the dissertation.
        /// </summary>
        public Guid ProjectId { get; set; }

        public StudentEntity Student { get; set; }
    }
}