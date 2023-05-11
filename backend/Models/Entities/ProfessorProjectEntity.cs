namespace gerdisc.Models.Entities
{
    public record ProfessorProjectEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the professor.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="ProfessorEntity"/> entity.
        /// </remarks>
        public Guid ProfessorId { get; set; }

        /// <summary>
        /// Gets or sets the professor navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="ProfessorEntity"/> entity.
        /// </remarks>
        public virtual ProfessorEntity Professor { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the project.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="ProjectEntity"/> entity.
        /// </remarks>
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="ProjectEntity"/> entity.
        /// </remarks>
        public virtual ProjectEntity Project { get; set; }

        public ProfessorProjectEntity()
        {
            Professor = new ProfessorEntity();
            Project = new ProjectEntity();
        }
    }
}