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
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key of the project associated with the dissertation.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property of the student that wrote the dissertation.
        /// </summary>
        public StudentEntity Student { get; set; }

        /// <summary>
        /// Gets or sets the navigation property of the project associated with the dissertation.
        /// </summary>
        public ProjectEntity Project { get; set; }

        public DissertationEntity()
        {
            Student = new StudentEntity();
            Project = new ProjectEntity();
        }
    }
}