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
        /// Gets or sets the unique identifier of the external researcher.
        /// </summary>
        /// <remarks>
        /// This property is a foreign key to the <see cref="ExternalResearcherEntity"/> entity.
        /// </remarks>
        public Guid? ExternalResearcherId { get; set; }

        /// <summary>
        /// Gets or sets the external researcher navigation property.
        /// </summary>
        /// <remarks>
        /// This property allows lazy loading of the <see cref="ExternalResearcherEntity"/> entity.
        /// </remarks>
        public virtual ExternalResearcherEntity ExternalResearcher { get; set; }

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
        public virtual DissertationEntity Dissertation { get; set; }

        public OrientationEntity()
        {
            Professor = new ProfessorEntity();
            ExternalResearcher = new ExternalResearcherEntity();
            Dissertation = new DissertationEntity();
        }
    }
}
