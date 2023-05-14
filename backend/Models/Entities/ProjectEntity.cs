namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a project in the system.
    /// </summary>
    public record ProjectEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the project.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the list of professors associated with the project.
        /// </summary>
        public List<ProfessorProjectEntity> ProfessorProjects { get; set; }

        /// <summary>
        /// Gets or sets the list of dissertations associated with the project.
        /// </summary>
        public List<DissertationEntity> Dissertations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        public ProjectEntity()
        {
            ProfessorProjects = new List<ProfessorProjectEntity>();
            Dissertations = new List<DissertationEntity>();
        }
    }
}