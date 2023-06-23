using System.ComponentModel.DataAnnotations.Schema;

namespace gerdisc.Models.Entities
{
    /// <summary>
    /// Represents a project in the system.
    /// </summary>
    [Table("Projects")]
    public record ProjectEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the research line.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="ResearchLineEntity"/> entity.
        /// </remarks>
        public Guid ResearchLineId { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the status of the project.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the list of professors associated with the project.
        /// </summary>
        public IEnumerable<ProfessorProjectEntity> ProfessorProjects { get; set; }

        /// <summary>
        /// Gets or sets the list of students associated with the project.
        /// </summary>
        public IEnumerable<StudentEntity> Students { get; set; }

        /// <summary>
        /// Gets or sets the list of orientations associated with the project.
        /// </summary>
        public IEnumerable<OrientationEntity> Orientations { get; set; }

        /// <summary>
        /// Gets or sets the list of research line associated with the project.
        /// </summary>
        public virtual ResearchLineEntity? ResearchLine { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        public ProjectEntity()
        {
            ProfessorProjects = new List<ProfessorProjectEntity>();
            Orientations = new List<OrientationEntity>();
            Students = new List<StudentEntity>();
        }
    }
}